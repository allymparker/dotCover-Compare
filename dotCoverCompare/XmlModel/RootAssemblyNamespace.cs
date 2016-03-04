using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespace : NamedCoverageBase
    {
        [XmlElement("Type")]
        public RootAssemblyNamespaceType[] Type { get; set; }
        
    }
}