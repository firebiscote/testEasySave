using System;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.Log.StateLog.Progress;

namespace testEasySave.Model.Data.Log.StateLog
{
    public class StateLog : IStateLog
    {
        public string SaveJobName { get; set; }
        public string Timestamp { get; set; }
        public string State { get; set; }
        public long TotalFilesTargeted { get; set; }
        public double TotalFilesTargetedSize { get; set; }
        public SaveJobProgress Progress { get; set; }

        public StateLog() { }

        private int GetTotalFilesOfADirectory(string directory)
        {
            return 10;
        }

        private double GetTotalFilesSizeOfADirectory(string directory)
        {
            return 100;
        }
    }
}
