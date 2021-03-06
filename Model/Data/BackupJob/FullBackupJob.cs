using System;
using System.Collections.Generic;
using System.IO;
using EasySave.Model.Data.BackupJob;
using EasySave.Model.Data.ToolBox;

namespace EasySave.Model.Data.Job
{
    public class FullBackupJob : AbstractBackupJob
    {
        public FullBackupJob() { }

        public override void Execute()
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

        public static event EventHandler<CopyFileEventArgs> FileCopied;
    }
}
