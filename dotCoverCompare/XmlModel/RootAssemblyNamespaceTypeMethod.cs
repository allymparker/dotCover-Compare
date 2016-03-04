using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeMethod : NamedCoverageBase, ICoverCollection<RootAssemblyNamespaceTypeMethodAnonymousMethod>
    {
        public RootAssemblyNamespaceTypeMethodOwnCoverage OwnCoverage { get; set; }


        [XmlElement("AnonymousMethod")]
        public RootAssemblyNamespaceTypeMethodAnonymousMethod[] Items { get; set; }
    }
}