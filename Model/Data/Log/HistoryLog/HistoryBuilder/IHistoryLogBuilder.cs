using System;

namespace testEasySave.Model.Data.Log.HistoryLog.HistoryBuilder
{
    public interface IHistoryLogBuilder
    {
        public IHistoryLog Log { get; set; }

        public void Reset();
        public void BuildSaveJobName(string name);
        public void BuildTimestamp();
        public void BuildSourceFileName(string sourceFileName);
        public void BuildTargetFileName(string stargetFileName);
        public void BuildFileSize(long size);
        public void BuildCopyDuration(DateTime start);
    }
}
