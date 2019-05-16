using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using static AnalyticStaticCode.Enum.EnumTypeXML;

namespace AnalyticStaticCode.Enum
{
    public class EnumTypeXML
    {
        public string Value { get; private set; }

        public EnumTypeXML(string value) => Value = value;

        public enum TypeEnum
        {
            [StringValue("Warnings Report")]
            WarningReport = 1,

            [StringValue("Code Reduction Report")]
            CodeReductionReport = 2,

            [StringValue("Optimization Report")]
            OptimizationReport = 3,

            [StringValue("Memory Report")]
            MemoryReport = 4
        }

        public static int GetEnumCodeByStringValue(string reportName)
        {
            string warningNameReport = TypeEnum.WarningReport.GetStringValue();
            string codeReductionReport = TypeEnum.CodeReductionReport.GetStringValue();
            string optimizationReport = TypeEnum.OptimizationReport.GetStringValue();
            string memoryReport = TypeEnum.MemoryReport.GetStringValue();

            if (warningNameReport == reportName)
            {
                return (int)TypeEnum.WarningReport;
            }
            if (codeReductionReport == reportName)
            {
                return (int)TypeEnum.CodeReductionReport;
            }
            if (optimizationReport == reportName)
            {
                return (int)TypeEnum.OptimizationReport;
            }
            if (memoryReport == reportName)
            {
                return (int)TypeEnum.MemoryReport;
            }
            else
            {
                return 0;
            }
        }
    }

    public static class ExtensionMethods
    {
        public static string GetStringValue(this TypeEnum value)
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValue[] attrs = fieldInfo.
                GetCustomAttributes(typeof(StringValue), false) as StringValue[];

            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }
            return stringValue;
        }      
    }

    public class StringValue : Attribute
    {
        public string Value { get; private set; }

        public StringValue(string value)
        {
            Value = value;
        }
    }
}
