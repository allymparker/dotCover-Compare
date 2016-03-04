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

        public Type CoverageType => typeof (T);

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

        public CoverageChange PercentChange
            =>
                CoverageChange(CoveragePercentDiff);

        public CoverageChange TotalStatementChange
            =>
                CoverageChange(TotalStatementsDiff);
        private CoverageChange CoverageChange(double diff)
        {
            return diff == 0
                ? Domain.CoverageChange.Unchanged
                : diff > 0 ? Domain.CoverageChange.Increased : Domain.CoverageChange.Decreased;
        }
    }
}