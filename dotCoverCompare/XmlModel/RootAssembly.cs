using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssembly : NamedCoverageBase, ICoverCollection<RootAssemblyNamespace>
    {
        [XmlElement("Namespace")]
        public RootAssemblyNamespace[] Items { get; set; }
    }
}