using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    public class CoverageBase
    {
        [XmlAttribute]
        public int CoveredStatements { get; set; }

        [XmlAttribute]
        public int TotalStatements { get; set; }

        public double CoveragePercent => (double)CoveredStatements/TotalStatements;

        protected bool Equals(CoverageBase other)
        {
            return CoveredStatements == other.CoveredStatements && TotalStatements == other.TotalStatements;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoverageBase) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CoveredStatements*397) ^ TotalStatements;
            }
        }

        public static bool operator ==(CoverageBase left, CoverageBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CoverageBase left, CoverageBase right)
        {
            return !Equals(left, right);
        }
    }
}