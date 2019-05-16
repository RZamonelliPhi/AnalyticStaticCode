using AnalyticStaticCode.Context;
using AnalyticStaticCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnalyticStaticCode.DL
{
    public class AnalyticProjectDB
    {
        public AnalyticProject analyticProject;

        private AnalyticProjectDB()
        {

        }

        private AnalyticProjectDB(AnalyticProject _analyticProject) => analyticProject = _analyticProject; 

        public static AnalyticProjectDB CreateObject(AnalyticProject analyticProject) => new AnalyticProjectDB(analyticProject);

        public static AnalyticProjectDB CreateObject() => new AnalyticProjectDB();

        public int SaveAnalyticProject()
        {
            using (AnalyticStaticCodeContext context = new AnalyticStaticCodeContext())
            {
                context.AnalyticProject.Add(analyticProject);
                context.SaveChanges();

                return analyticProject.Id;
            }
        }

        public AnalyticProject SelectAnalyticProjectByCodeReport(int codeReport)
        {
            using (AnalyticStaticCodeContext context = new AnalyticStaticCodeContext())
            {
                var analyticProject = (from ar in context.AnalyticProject
                                                    where ar.Code == codeReport
                                                    select ar)
                                                    .FirstOrDefault<AnalyticProject>();


                return analyticProject ?? new AnalyticProject();
            }
        }
    }
}
