﻿using System;
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

        private FullSaveJob() { }

        public FullSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Name = name;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
            Type = Parameters.FullSaveJobType;
        }

        public void Execute()
        {
            List<string> files = GetFiles();
            foreach (string fileName in files.ToArray())
            {
                FileInfo file = new FileInfo(fileName);
                StartCopy.Invoke(this, EventArgs.Empty);
                file.CopyTo(TargetDirectory + file.Name);
                FileCopied.Invoke(this, new FileEventArgs(file));
                files.Remove(fileName);
            }
        }

        public List<string> GetFiles()
        {
            return Directory.GetFiles(SourceDirectory, "*", SearchOption.AllDirectories).ToList();
        }

        public static event EventHandler StartCopy;
        public static event EventHandler<FileEventArgs> FileCopied;
    }
}
