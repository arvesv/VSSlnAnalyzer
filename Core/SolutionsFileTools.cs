using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Core
{
    public class SolutionFileTools
    {
        public static bool Analyze(FileInfo solutionFile)
        {
            var solutionFileDir = solutionFile.DirectoryName;
            var allLines = File.ReadAllLines(solutionFile.FullName);

            var projects = GetCSharpProjects(allLines);

            return false;
        }

        public static string[] GetCSharpProjects(string[] slnContent)
        {
            return slnContent
                .Select(GetProjectPath)
                .Where(line => null != line)
                .ToArray();
        }

        public static string  GetProjectPath(string line)
        {
            if(line == null) return null;
            if (line.StartsWith("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \""))
            {
                var arr = line.Split(',');
                return arr[1].Replace("\"","").Trim();
            }
            return null;
        }
    }
}
