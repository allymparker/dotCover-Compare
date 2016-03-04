using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeType : NamedCoverageBase
    {
        public RootAssemblyNamespaceTypeTypeConstructor Constructor { get; set; }


        [XmlElement("Property")]
        public RootAssemblyNamespaceTypeTypeProperty[] Property { get; set; }


        public RootAssemblyNamespaceTypeTypeMethod Method { get; set; }
    }
}