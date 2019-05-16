using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AnalyticStaticCode.BL
{
    public class INIFile
    {
        private string filePath;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);

        public INIFile(string filePath)
        {
            this.filePath = filePath;
        }
        
        public string Read(string section, string key)
        {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
            return SB.ToString();
        }

        public string FilePath
        {
            get => filePath;
            set => filePath = value;
        }
    }
}
