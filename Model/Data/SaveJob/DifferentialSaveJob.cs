﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testEasySave.Model.Data.ToolBox;

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
            Type = Parameters.DifferencialSaveJobType;
        }

        public void Execute()
        {
            List<string> files = GetFiles();
            foreach (string fileName in files.ToArray())
            {
                FileInfo file = new FileInfo(fileName);
                FileInfo targetFile = new FileInfo(TargetDirectory + file.Name);
                if (!targetFile.Exists || targetFile.LastWriteTimeUtc < file.LastWriteTimeUtc)
                {
                    targetFile.Delete();
                    StartCopy.Invoke(this, EventArgs.Empty);
                    file.CopyTo(targetFile.FullName);
                    FileCopied.Invoke(this, new FileEventArgs(file));
                    files.Remove(fileName);
                }
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
