using System.ComponentModel;
using System.Xml.Serialization;

namespace dotCoverCompare.XmlModel
{
    interface ICoverCollection<T> where T:CoverageBase
    {
        T[] Items { get; set; }    
    }

    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Root:CoverageBase, ICoverCollection<RootAssembly>
    {
        [XmlElement("Assembly")]
        public RootAssembly[] Items { get; set; }

        [XmlAttribute]
        public string ReportType { get; set; }

        [XmlAttribute]
        public string DotCoverVersion { get; set; }
    }
}