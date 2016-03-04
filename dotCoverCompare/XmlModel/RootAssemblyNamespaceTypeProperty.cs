using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeProperty : NamedCoverageBase
    {
        public RootAssemblyNamespaceTypePropertyPropertyGetter PropertyGetter { get; set; }


        public RootAssemblyNamespaceTypePropertyPropertySetter PropertySetter { get; set; }

    }
}