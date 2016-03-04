using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Root:CoverageBase
    {
        [XmlElement("Assembly")]
        public RootAssembly[] Assembly { get; set; }

        [XmlAttribute]
        public string ReportType { get; set; }

        [XmlAttribute]
        public string DotCoverVersion { get; set; }
    }
}