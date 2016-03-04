using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceType : NamedCoverageBase, ICoverCollection<CoverageBase>
    {
        [XmlElement("Constructor", typeof (RootAssemblyNamespaceTypeConstructor))]
        [XmlElement("Method", typeof (RootAssemblyNamespaceTypeMethod))]
        [XmlElement("Property", typeof (RootAssemblyNamespaceTypeProperty))]
        [XmlElement("Type", typeof (RootAssemblyNamespaceTypeType))]
        public CoverageBase[] Items { get; set; }

        
    }
}