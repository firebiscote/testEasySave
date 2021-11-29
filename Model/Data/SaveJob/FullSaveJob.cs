using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.Job
{
    public class FullSaveJob : ISaveJob
    {
        public string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string Type { get; set; }

        public FullSaveJob() { }

        public void Execute()
        {
            List<string> files = GetFiles();
            foreach (string fileName in files.ToArray())
            {
                FileInfo file = new FileInfo(fileName);
                CreateSubDirectory(file.FullName);
                DateTime start = DateTime.Now;
                file.CopyTo(TargetDirectory + file.FullName[SourceDirectory.Length..], true);
                files.Remove(fileName);
                FileCopied.Invoke(this, new CopyFileEventArgs(start, file, files.ToArray()));
            }
        }

        private void CreateSubDirectory(string fileName)
        {
            DirectoryInfo directory = new DirectoryInfo(TargetDirectory + fileName[(SourceDirectory.Length-1)..fileName.LastIndexOf("\\")]);
            if (!directory.Exists)
                directory.Create();
        }

        public List<string> GetFiles()
        {
            return Directory.GetFiles(SourceDirectory, "*", SearchOption.AllDirectories).ToList();
        }

        public static event EventHandler<CopyFileEventArgs> FileCopied;
    }
}
