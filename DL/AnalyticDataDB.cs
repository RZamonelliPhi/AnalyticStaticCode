using AnalyticStaticCode.Context;
using AnalyticStaticCode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnalyticStaticCode.DL
{
    public class AnalyticDataDB
    {
        public AnalyticData analyticData;

        private AnalyticDataDB(AnalyticData _analyticData) => analyticData = _analyticData;

        public static AnalyticDataDB CreateObject(AnalyticData analyticData) => new AnalyticDataDB(analyticData);

        public int SaveAnalyticData()
        {
           using (AnalyticStaticCodeContext context = new AnalyticStaticCodeContext())
           {       
             context.AnalyticData.Add(analyticData);
             context.SaveChanges();

             return analyticData.Id;             
           }          
        }
    }
}
