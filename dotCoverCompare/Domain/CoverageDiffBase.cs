using System;
using dotCoverCompare.XmlModel;

namespace dotCoverCompare.Domain
{
    public abstract class CoverageDiffBase<T> where T: CoverageBase
    {
        protected readonly T Current;
        protected readonly T Previous;

        protected CoverageDiffBase(T previous, T current)
        {
            if (previous == null) throw new ArgumentNullException(nameof(previous));
            if (current == null) throw new ArgumentNullException(nameof(current));

            Previous = previous;
            Current = current;
        }

        public Type CoverageType => typeof (T);

        public int CurrentCoveredStatements => Current.CoveredStatements;

        public int CurrentTotalStatements => Current.TotalStatements;

        public double CurrentCoveragePercent => Current.CoveragePercent;

        public int PreviousCoveredStatements => Previous.CoveredStatements;

        public int PreviousTotalStatements => Previous.TotalStatements;

        public double PreviousCoveragePercent => Previous.CoveragePercent;

        public int CoveredStatementsDiff => PreviousCoveredStatements - CurrentCoveredStatements;

        public int TotalStatementsDiff => PreviousTotalStatements - CurrentTotalStatements;

        public double CoveragePercentDiff => PreviousCoveragePercent - CurrentCoveragePercent;
    }
}