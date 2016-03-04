using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeTypeProperty : NamedCoverageBase
    {
        public RootAssemblyNamespaceTypeTypePropertyPropertyGetter PropertyGetter { get; set; }


        public RootAssemblyNamespaceTypeTypePropertyPropertySetter PropertySetter { get; set; }
        
    }
}