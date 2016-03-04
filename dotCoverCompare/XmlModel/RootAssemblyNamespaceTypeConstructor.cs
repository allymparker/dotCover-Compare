using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RootAssemblyNamespaceTypeConstructor : NamedCoverageBase
    {
        public RootAssemblyNamespaceTypeConstructorOwnCoverage OwnCoverage { get; set; }


        public RootAssemblyNamespaceTypeConstructorAnonymousMethod AnonymousMethod { get; set; }

        
    }
}