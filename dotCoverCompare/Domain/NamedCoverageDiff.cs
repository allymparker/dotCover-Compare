using dotCoverCompare.XmlModel;

namespace dotCoverCompare.Domain
{
    public class NamedCoverageDiff : CoverageDiffBase<NamedCoverageBase>
    {
        public NamedCoverageDiff(NamedCoverageBase previous, NamedCoverageBase current)
            : base(previous, current)
        {
        }

        public string Name => Previous.Name;
    }
}