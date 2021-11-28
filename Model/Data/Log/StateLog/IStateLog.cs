using System;
using testEasySave.Model.Data.Log.StateLog.Progress;

namespace testEasySave.Model.Data.Log.StateLog
{
    public interface IStateLog
    {
        public string SaveJobName { get; set; }
        public string Timestamp { get; set; }
        public string State { get; set; }
        public long TotalFilesTargeted { get; set; }
        public double TotalFilesTargetedSize { get; set; }
        public SaveJobProgress Progress { get; set; }
    }
}
