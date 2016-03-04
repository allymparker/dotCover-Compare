using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Root:CoverageBase, ICoverageCollection
    {
        [XmlElement("Assembly", typeof(RootAssembly))]
        public NamedCoverageBase[] Items { get; set; }

        [XmlAttribute]
        public string ReportType { get; set; }

        [XmlAttribute]
        public string DotCoverVersion { get; set; }
    }
}