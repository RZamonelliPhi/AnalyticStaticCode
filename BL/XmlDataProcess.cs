using System;
using System.Collections.Generic;
using System.Text;
using AnalyticStaticCode.Context;
using AnalyticStaticCode.Model;
using AnalyticStaticCode.Enum;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static AnalyticStaticCode.Enum.EnumTypeXML;
using AnalyticStaticCode.DL;

namespace AnalyticStaticCode.BL
{
    public class XmlDataProcess
    {
        INIFile inif = new INIFile(Path.Combine(Environment.CurrentDirectory, "config.ini"));

        private XmlDataProcess()
        {
        }

        public static XmlDataProcess CreateObject() => new XmlDataProcess();

        public XElement ReadXML(string fileName) {

            try
            {
                return XElement.Load(fileName);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public string GetReportName(string fileName)
        {
            try
            {
               return ReadXML(fileName).Attribute("name").Value.Trim();
            }
            catch(Exception e){
                return null;
            }        
        }

        public void IdentifyTypeReport(string buildNumber, string projectName, string folderName)
        {
            var ext = new List<string> { ".xml" };

            string[] fileEntries = Directory.GetFiles(Path.Combine(inif.Read("XMLPath", "PathFilesXML"), folderName)).Where(s=> ext.Contains(Path.GetExtension(s))).ToArray();

            foreach (string fileName in fileEntries)
            {
                try
                {
                    XElement fileXML = ReadXML(fileName);
                    int analyticReportId = ProcessHeaderXMLReport(fileXML, fileName);

                    if (analyticReportId != 0)
                    {
                        int analyticProjectId = ProcessXMLProject(projectName);
                        int analyticReportAuxId = 0;

                        AnalyticReportAux dataAnalyticReportAux = AnalyticReportAuxDB.CreateObject().SelectAnalyticReportByCodeReport(analyticReportId, buildNumber, analyticProjectId);

                        if (dataAnalyticReportAux.Id == 0)
                        {
                            AnalyticReportAux analyticReportAux = new AnalyticReportAux
                            {
                                BuildNumber = buildNumber,
                                DateAnalyticReportAux = DateTime.Now,
                                AnalyticReportId = analyticReportId,
                                AnalyticProjectId = analyticProjectId,
                                XmlInfo = fileXML.ToString()
                            };

                            analyticReportAuxId = AnalyticReportAuxDB.CreateObject(analyticReportAux).SaveAnalyticReportAux();

                            ProcessXMLData(fileXML, analyticReportAuxId);
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Exception error: '{e}' - File name error: "+ fileName + "");
                }            
            }
        }

        public int ProcessHeaderXMLReport(XElement fileXML, string fileName)
        {
            var reportName = GetReportName(fileName);
            var codeReport = EnumTypeXML.GetEnumCodeByStringValue(reportName);

            AnalyticReport dataAnalyticReport = AnalyticReportDB.CreateObject().SelectAnalyticReportByCodeReport(EnumTypeXML.GetEnumCodeByStringValue(GetReportName(fileName)));
            AnalyticReport analyticReport = new AnalyticReport();
                     
            if (codeReport != 0 && reportName != "null")
            {
                if (dataAnalyticReport.Id != 0)
                {
                    analyticReport.Id = dataAnalyticReport.Id;
                }
                else
                {
                    analyticReport.Name = reportName;
                    analyticReport.Code = EnumTypeXML.GetEnumCodeByStringValue(reportName);
                    analyticReport.Id = AnalyticReportDB.CreateObject(analyticReport).SaveAnalyticReport();
                }
            }

            return analyticReport.Id;
        }

        public void ProcessXMLData(XElement fileXML, int analyticReportAuxId)
        {
            IEnumerable<XElement> elems = fileXML.Descendants("section");

            foreach (XElement x in elems)
            {
                AnalyticData analyticData = new AnalyticData
                {
                    Section = x.Attribute("name").Value,
                    Quantity = x.Attribute("count") == null ? 0 : Convert.ToInt32(x.Attribute("count").Value),
                    AnalyticReportAuxId = analyticReportAuxId
                };

                AnalyticDataDB.CreateObject(analyticData).SaveAnalyticData();
            }
        }

        public int ProcessXMLProject(string analyticProjectName)
        {
            AnalyticProject dataAnalyticReport = AnalyticProjectDB.CreateObject().SelectAnalyticProjectByCodeReport(EnumProjectReport.GetEnumCodeByStringValue(analyticProjectName));
            AnalyticProject analyticProject = new AnalyticProject();

            if (dataAnalyticReport.Id != 0)
            {
                analyticProject.Id = dataAnalyticReport.Id;
            }
            else
            {
                analyticProject.Name = analyticProjectName;
                analyticProject.Code = EnumProjectReport.GetEnumCodeByStringValue(analyticProjectName);
                analyticProject.Id = AnalyticProjectDB.CreateObject(analyticProject).SaveAnalyticProject();
            }

            return analyticProject.Id;
        }
    }
}
