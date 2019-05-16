using AnalyticStaticCode.BL;
using System;


namespace AnalyticStaticCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string buildNumber = args[0];
                string projectName = args[1];
                string folderName = args[2];

                XmlDataProcess.CreateObject().IdentifyTypeReport(buildNumber, projectName, folderName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }
    }
}
