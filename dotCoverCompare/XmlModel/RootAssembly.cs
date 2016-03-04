using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssembly : NamedCoverageBase
    {
        [XmlElement("Namespace")]
        public RootAssemblyNamespace[] Namespace { get; set; }
    }
}