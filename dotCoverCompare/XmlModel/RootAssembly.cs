using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssembly : NamedCoverageBase, ICoverageCollection
    {
        [XmlElement("Namespace", typeof(RootAssemblyNamespace))]
        public NamedCoverageBase[] Items { get; set; }
    }
}