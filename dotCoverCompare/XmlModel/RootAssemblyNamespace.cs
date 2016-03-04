using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespace : NamedCoverageBase, ICoverageCollection
    {
        [XmlElement("Type", typeof(RootAssemblyNamespaceType))]
        public NamedCoverageBase[] Items { get; set; }
        
    }
}