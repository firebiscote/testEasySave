using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace testEasySave.Model.Data.Job
{
    class DifferentialSaveJob : ISaveJob
    {
        public string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string Type { get; set; }

        private DifferentialSaveJob() { }

        public DifferentialSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Name = name;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
            Type = "Differential";
        }

        public void Execute()
        {
            List<string> files = GetFiles();
            foreach (string file in files.ToArray())
            {
                string fileName = file[file.LastIndexOf('\\')..];
                string targetFile = TargetDirectory + fileName;
                if (!File.Exists(targetFile) || File.GetLastWriteTime(targetFile) < File.GetLastWriteTime(file))
                {
                    File.Delete(targetFile);
                    File.Copy(file, targetFile);
                    files.Remove(file);
                }
            }
        }

        public List<string> GetFiles()
        {
            return Directory.GetFiles(SourceDirectory, "*", SearchOption.AllDirectories).ToList();
        }
    }
}
