using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeType : NamedCoverageBase, ICoverCollection<RootAssemblyNamespaceTypeTypeProperty>
    {
        public RootAssemblyNamespaceTypeTypeConstructor Constructor { get; set; }


        [XmlElement("Property")]
        public RootAssemblyNamespaceTypeTypeProperty[] Items { get; set; }


        public RootAssemblyNamespaceTypeTypeMethod Method { get; set; }
    }
}