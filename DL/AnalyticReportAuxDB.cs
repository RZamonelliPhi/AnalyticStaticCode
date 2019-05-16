using AnalyticStaticCode.Context;
using AnalyticStaticCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyticStaticCode.DL
{
    public class AnalyticReportAuxDB
    {
        public AnalyticReportAux analyticReportAux;

        private AnalyticReportAuxDB()
        {

        }

        private AnalyticReportAuxDB(AnalyticReportAux _analyticReportAux) => analyticReportAux = _analyticReportAux;

        public static AnalyticReportAuxDB CreateObject(AnalyticReportAux analyticReportAux) => new AnalyticReportAuxDB(analyticReportAux);

        public static AnalyticReportAuxDB CreateObject() => new AnalyticReportAuxDB();

        public int SaveAnalyticReportAux()
        {
            using (var context = new AnalyticStaticCodeContext())
            {
                context.AnalyticReportAux.Add(analyticReportAux);
                context.SaveChanges();

                return analyticReportAux.Id;
            }
        }

        public AnalyticReportAux SelectAnalyticReportByCodeReport(int analyticReportId, string buildNumber, int analyticProjectId)
        {
            using (AnalyticStaticCodeContext context = new AnalyticStaticCodeContext())
            {
               var analyticReport = (from ar in context.AnalyticReportAux
                                     where ar.BuildNumber == buildNumber 
                                       &&  ar.AnalyticReportId == analyticReportId
                                       && ar.AnalyticProjectId == analyticProjectId
                                     select ar)
                                    .FirstOrDefault<AnalyticReportAux>();


                return analyticReport ?? new AnalyticReportAux();
            }
        }
    }
}
