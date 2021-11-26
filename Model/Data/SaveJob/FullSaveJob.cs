﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace testEasySave.Model.Data.Job
{
    public class FullSaveJob : ISaveJob
    {
        public string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string Type { get; set; }

        private FullSaveJob() { }

        public FullSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Name = name;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
            Type = "Full";
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