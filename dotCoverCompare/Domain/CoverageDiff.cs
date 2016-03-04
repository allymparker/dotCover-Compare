using dotCoverCompare.XmlModel;

namespace dotCoverCompare.Domain
{
    public class CoverageDiff : CoverageDiffBase<CoverageBase>
    {
        public CoverageDiff(CoverageBase previous, CoverageBase current)
            : base(previous, current)
        {
        }
    }
}