using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.SaveJob
{
    public abstract class AbstractSaveJob : ISaveJob
    {
        public string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string Type { get; set; }

        public abstract void Execute();

        protected void CreateSubDirectory(string fileName)
        {
            // Get the file subdirectory
            DirectoryInfo directory = new DirectoryInfo(TargetDirectory + fileName[(TargetDirectory.Length - 1)..fileName.LastIndexOf("\\")]);
            if (!directory.Exists)
                directory.Create();
        }

        protected List<string> GetFiles()
        {
            return Directory.GetFiles(SourceDirectory, "*", SearchOption.AllDirectories).ToList();
        }
    }
}
