using AnalyticStaticCode.Context;
using AnalyticStaticCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyticStaticCode.DL
{
    public class AnalyticReportDB
    {
        public AnalyticReport analyticReport;

        private AnalyticReportDB(AnalyticReport _analyticReport) => analyticReport = _analyticReport;

        private AnalyticReportDB()
        {
           
        }

        public static AnalyticReportDB CreateObject(AnalyticReport analyticReport) => new AnalyticReportDB(analyticReport);

        public static AnalyticReportDB CreateObject() => new AnalyticReportDB();

        public int SaveAnalyticReport()
        {
            using (AnalyticStaticCodeContext context = new AnalyticStaticCodeContext())
            {
                context.AnalyticReport.Add(analyticReport);
                context.SaveChanges();

                return analyticReport.Id;
            }
        }

        public AnalyticReport SelectAnalyticReportByCodeReport(int codeReport)
        {
            using (AnalyticStaticCodeContext context = new AnalyticStaticCodeContext())
            {
               var analyticReport = (from ar in context.AnalyticReport
                                     where ar.Code == codeReport
                                     select ar)
                                     .FirstOrDefault<AnalyticReport>();


                return analyticReport ?? new AnalyticReport();
            }
        }
    }
}
