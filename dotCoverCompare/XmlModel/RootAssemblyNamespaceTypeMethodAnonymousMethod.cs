using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeMethodAnonymousMethod : NamedCoverageBase, ICoverCollection<RootAssemblyNamespaceTypeMethodAnonymousMethodAnonymousMethod>
    {
        public RootAssemblyNamespaceTypeMethodAnonymousMethodOwnCoverage OwnCoverage { get; set; }


        [XmlElement("AnonymousMethod")]
        public RootAssemblyNamespaceTypeMethodAnonymousMethodAnonymousMethod[] Items { get; set; }

        
    }
}