using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace AnalyticStaticCode.Model
{
    public class AnalyticReportAux
    {
        public int Id { get; set; }
        public string BuildNumber { get; set; }
        public DateTime DateAnalyticReportAux { get; set; }

        [Column(TypeName = "xml")]
        public string XmlInfo { get; set; }

        [ForeignKey("AnalyticReportFK")]
        public int AnalyticReportId { get; set; }

        [ForeignKey("AnalyticProjectFK")]
        public int AnalyticProjectId { get; set; }

        public ICollection<AnalyticData> ListAnalyticData { get; set; }

        [NotMapped]
        public XElement MyXmlColumn
        {
            get { return XElement.Parse(XmlInfo); }
            set { XmlInfo = value.ToString(); }
        }
    }
}
