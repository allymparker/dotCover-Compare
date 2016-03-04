using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeMethod : NamedCoverageBase, ICoverageCollection
    {
        public RootAssemblyNamespaceTypeMethodOwnCoverage OwnCoverage { get; set; }


        [XmlElement("AnonymousMethod", typeof(RootAssemblyNamespaceTypeMethodAnonymousMethod))]
        public NamedCoverageBase[] Items { get; set; }
    }
}