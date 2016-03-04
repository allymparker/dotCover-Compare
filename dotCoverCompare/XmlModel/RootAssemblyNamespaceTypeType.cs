using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeType : NamedCoverageBase, ICoverageCollection
    {
        public RootAssemblyNamespaceTypeTypeConstructor Constructor { get; set; }


        [XmlElement("Property",typeof(RootAssemblyNamespaceTypeTypeProperty))]
        public NamedCoverageBase[] Items { get; set; }


        public RootAssemblyNamespaceTypeTypeMethod Method { get; set; }
    }
}