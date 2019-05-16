﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticStaticCode.Model
{
    public class AnalyticProject
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public ICollection<AnalyticReportAux> ListAnalyticReportAux { get; set; }
    }
}
