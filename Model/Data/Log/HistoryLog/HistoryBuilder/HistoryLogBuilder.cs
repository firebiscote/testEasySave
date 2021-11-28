using System;

namespace testEasySave.Model.Data.Log.HistoryLog.HistoryBuilder
{
    public class HistoryLogBuilder : IHistoryLogBuilder
    {
        public IHistoryLog Log { get; set; }

        public void Reset()
        {
            Log = new HistoryLog();
        }

        public void BuildSaveJobName(string name)
        {
            Log.SaveJobName = name;
        }

        public void BuildTimestamp()
        {
            Log.Timestamp = DateTime.Now.ToString(Parameters.HistoryLogTimestampFormat);
        }

        public void BuildSourceFileName(string sourceFileName)
        {
            Log.SourceFileName = sourceFileName;
        }

        public void BuildTargetFileName(string targetFileName)
        {
            Log.TargetFileName = targetFileName;
        }

        public void BuildFileSize(long size)
        {
            Log.FileSize = size;
        }

        public void BuildCopyDuration(DateTime start)
        {
            Log.CopyDuration = (DateTime.Now - start).TotalMilliseconds;
        }
    }
}
