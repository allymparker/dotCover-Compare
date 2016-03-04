using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeMethodAnonymousMethod : NamedCoverageBase, ICoverageCollection
    {
        public RootAssemblyNamespaceTypeMethodAnonymousMethodOwnCoverage OwnCoverage { get; set; }


        [XmlElement("AnonymousMethod", typeof(RootAssemblyNamespaceTypeMethodAnonymousMethodAnonymousMethod))]
        public NamedCoverageBase[] Items { get; set; }

        
    }
}