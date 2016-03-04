using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeMethodAnonymousMethod : NamedCoverageBase
    {
        public RootAssemblyNamespaceTypeMethodAnonymousMethodOwnCoverage OwnCoverage { get; set; }


        [XmlElement("AnonymousMethod")]
        public RootAssemblyNamespaceTypeMethodAnonymousMethodAnonymousMethod[] AnonymousMethod { get; set; }

        
    }
}