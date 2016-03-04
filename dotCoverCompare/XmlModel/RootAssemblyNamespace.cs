using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespace : NamedCoverageBase, ICoverCollection<RootAssemblyNamespaceType>
    {
        [XmlElement("Type")]
        public RootAssemblyNamespaceType[] Items { get; set; }
        
    }
}