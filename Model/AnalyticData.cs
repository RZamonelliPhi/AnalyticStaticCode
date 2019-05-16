using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AnalyticStaticCode.Model
{
    public class AnalyticData
    {
        public int Id { get; set; }
        public String Section { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("AnalyticReportAuxFK")]
        public Int32 AnalyticReportAuxId { get; set; }
    }
}
