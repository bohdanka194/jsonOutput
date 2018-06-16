using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonOutputForFolderPath
{
    class JsonHelper
    {
        private static readonly string newLine = Environment.NewLine;
        private const string tab1 = "\t";
        private const string tab2 = "\t\t";

        public static string FormatJson(string path, string tab = "")
        {
            DirectoryInfo mydir = new DirectoryInfo(path);
            string json = string.Empty;
            json += tab + "{" + newLine;
            json += tab + tab1 + "\"Name\": " + "\"" + mydir.Name + "\"," + newLine;
            json += tab + tab1 + "\"DataCreated\": " + "\"" + mydir.CreationTime + "\"," + newLine;
            json += tab + tab1 + "\"Files\": " + "[" + GetInfoFiles(path, tab) + "]," + newLine;
            json += tab + tab1 + "\"Children\": " + "[" + GetInfoChildren(path, tab + tab2) + "]" + newLine;
            json += tab + "}";

            return json;
        }
        private static string GetInfoFiles(string path, string tab = "")
        {
            FileInfo[] files = new DirectoryInfo(path).GetFiles();
            if (files.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                string json = string.Empty;
                foreach (var file in files)
                {
                    json += newLine + tab + tab1 +"   {" + newLine;
                    json += tab + tab2 + "\"Name\": " + "\"" + file.Name + "\"," + newLine;
                    json += tab + tab2 + "\"Size\": " + "\"" + file.Length + " B\"," + newLine;
                    json += tab + tab2 + "\"Path\": " + "\"" + file.FullName + "\"" + newLine;
                    json += tab + tab1 + "   },";
                }
                json += newLine + tab1 + tab;
                return json;
            }
        }
        private static string GetInfoChildren(string path, string tab = "\t")
        {
            DirectoryInfo[] subdirectories = new DirectoryInfo(path).GetDirectories();
            if (subdirectories.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                string json = newLine;
                foreach (var subdir in subdirectories)
                {
                    json += FormatJson(subdir.FullName, tab);

                    json += "," + newLine;
                }
                string lessTab = tab.Substring(0, tab.Length - 1);
                json += lessTab;
                return json;
            }
        }
    }
}
