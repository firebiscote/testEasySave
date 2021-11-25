using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.Job
{
    public class CompleteSaveJob : ISaveJob
    {
        public string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string Type { get; set; }

        private CompleteSaveJob() { }

        public CompleteSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Name = name;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
            Type = "Complete";
        }

        public void Execute()
        {
            List<string> files = GetFiles();
            foreach (string file in files.ToArray())
            {
                string fileName = file[file.LastIndexOf('\\')..];
                File.Copy(file, TargetDirectory + fileName);
                files.Remove(file);
            }
        }

        public List<string> GetFiles()
        {
            return Directory.GetFiles(SourceDirectory, "*", SearchOption.AllDirectories).ToList();
        }
    }
}
