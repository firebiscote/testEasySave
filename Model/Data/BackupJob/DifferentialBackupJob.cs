using System;
using System.Collections.Generic;
using System.IO;
using testEasySave.Model.Data.BackupJob;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.Job
{
    class DifferentialBackupJob : AbstractBackupJob
    {
        public DifferentialBackupJob() { }

        public override void Execute()
        {
            List<string> files = GetFiles();
            foreach (string fileName in files.ToArray())
            {
                FileInfo file = new FileInfo(fileName);
                FileInfo targetFile = new FileInfo(TargetDirectory + file.FullName[SourceDirectory.Length..]);
                if (!targetFile.Exists || targetFile.LastWriteTimeUtc < file.LastWriteTimeUtc)
                {
                    CreateSubDirectory(targetFile.FullName);
                    targetFile.Delete();
                    DateTime start = DateTime.Now;
                    file.CopyTo(targetFile.FullName);
                    files.Remove(fileName);
                    FileCopied.Invoke(this, new CopyFileEventArgs(start, file, files.ToArray()));
                }
            }
        }

        public static event EventHandler<CopyFileEventArgs> FileCopied;
    }
}
