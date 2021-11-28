using testEasySave.Model.Data.Log.StateLog.Progress;

namespace testEasySave.Model.Data.Log.StateLog
{
    public class StateLog : IStateLog
    {
        public string SaveJobName { get; set; }
        public string Timestamp { get; set; }
        public string State { get; set; }
        public int TotalTargetedFiles { get; set; }
        public long TotalTargetedFilesSize { get; set; }
        public SaveJobProgress Progress { get; set; }

        public StateLog() { }
    }
}
