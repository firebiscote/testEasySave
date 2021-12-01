using System;
using System.IO;
using EasySave.Model.Data.Job;

namespace EasySave.Model.Data.Log.HistoryLog.HistoryBuilder
{
    public class HistoryLogDirector
    {
        public static HistoryLogDirector Instance = new HistoryLogDirector();
        public IHistoryLogBuilder Builder { get; set; }

        private HistoryLogDirector()
        {
            Builder = new HistoryLogBuilder();
        }

        public IHistoryLog GetNewHistoryLog(IBackupJob saveJob, FileInfo file, DateTime start)
        {
            Builder.Reset();
            Builder.BuildCopyDuration(start);
            Builder.BuildTimestamp();
            Builder.BuildSaveJobName(saveJob.Name);
            Builder.BuildSourceFileName(file.FullName);
            Builder.BuildTargetFileName(saveJob.TargetDirectory + file.FullName[saveJob.SourceDirectory.Length..]);
            Builder.BuildFileSize(file.Length);
            return Builder.Log;
        }
    }
}
