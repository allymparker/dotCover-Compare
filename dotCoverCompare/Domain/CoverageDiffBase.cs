using System;
using dotCoverCompare.XmlModel;

namespace dotCoverCompare.Domain
{
    public abstract class CoverageDiffBase<T> where T: CoverageBase, new()
    {
        protected readonly T Current;
        protected readonly T Previous;

        protected CoverageDiffBase(T previous, T current)
        {
            Previous = previous ?? new T();
            Current = current ?? new T(); 
        }

        public Type CoverageType => Previous?.GetType()??Current.GetType();

        public int CurrentCoveredStatements => Current.CoveredStatements;

        public int CurrentTotalStatements => Current.TotalStatements;

        public double CurrentCoveragePercent => Current.TotalStatements == 0 ? 0: Current.CoveragePercent;

        public int PreviousCoveredStatements => Previous.CoveredStatements;

        public int PreviousTotalStatements => Previous.TotalStatements;

        public double PreviousCoveragePercent => Previous.TotalStatements == 0 ? 0 : Previous.CoveragePercent;

        public int CoveredStatementsDiff => PreviousCoveredStatements - CurrentCoveredStatements;

        public int TotalStatementsDiff => PreviousTotalStatements - CurrentTotalStatements;

        public double CoveragePercentDiff 
        {
            get
            {
                if (Previous.TotalStatements == 0) return CurrentCoveragePercent;
                if (Current.TotalStatements == 0) return -PreviousCoveragePercent;

                return PreviousCoveragePercent - CurrentCoveragePercent;
            }
        }

        public CoverageChange CoverageChangeType
        {
            get
            {
                if (CoveragePercentDiff == 0) return CoverageChange.Unchanged;
                return CoveragePercentDiff > 0
                        ? CoverageChange.Increased
                        : CoverageChange.Decreased;
            }
        }

        public CodeChange StatementChangeType
        {
            get
            {
                if (PreviousTotalStatements == 0) return CodeChange.Added;
                if(CurrentTotalStatements == 0) return CodeChange.Removed;

                return TotalStatementsDiff > 0 ? CodeChange.StatementsIncreased : CodeChange.StatementsDecreased;
            }
        }
    }
}