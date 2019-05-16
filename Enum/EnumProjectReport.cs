using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static AnalyticStaticCode.Enum.EnumProjectReport;

namespace AnalyticStaticCode.Enum
{
    public class EnumProjectReport
    {
        public string Value { get; private set; }

        public EnumProjectReport(string value) => Value = value;

        public enum EnumProject
        {
            [StringValueProject("DataCenter.dproj")]
            DataCenter = 1,

            [StringValueProject("XIMS.dproj")]
            XIMS = 2,

            [StringValueProject("XimsTest.dproj")]
            XimsTest = 3
        }

        public static int GetEnumCodeByStringValue(string projectName)
        {
            string dataCenterReport = EnumProject.DataCenter.GetStringValue();
            string ximsReport = EnumProject.XIMS.GetStringValue();
            string ximsTestReport = EnumProject.XimsTest.GetStringValue();

            if (dataCenterReport == projectName)
            {
                return (int)EnumProject.DataCenter;
            }
            if (ximsReport == projectName) 
            {
                return (int)EnumProject.XIMS;
            }
            if (ximsTestReport == projectName)
            {
                return (int)EnumProject.XimsTest;
            }
            else
            {
                return 0;
            }
        }
    }

    public static class ExtensionMethodsProjetReport
    {
        public static string GetStringValue(this EnumProject value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueProject[] attrs = fieldInfo.
                GetCustomAttributes(typeof(StringValueProject), false) as StringValueProject[];
            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }
            return stringValue;
        }
    }

    public class StringValueProject : Attribute
    {
        public string Value { get; private set; }

        public StringValueProject(string value) => Value = value;
    }
}
