using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    public class NamedCoverageBase : CoverageBase
    {
        [XmlAttribute]
        public string Name { get; set; }

        protected bool Equals(NamedCoverageBase other)
        {
            return base.Equals(other) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NamedCoverageBase) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}