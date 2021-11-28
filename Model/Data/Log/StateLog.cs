using System;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.Log
{
    public class StateLog
    {
        public string SaveJobName { get; }
        public DateTime Timestamp { get; }
        public string State { get; }
        public int TotalFilesTargeted { get; }
        public double TotalFilesTargetedSize { get; }
        public SaveJobProgress Progress { get; }

        public StateLog(ISaveJob saveJob, string actualFileName) 
        {
            SaveJobName = saveJob.Name;
            Timestamp = DateTime.Now;
            State = actualFileName == "" ? Parameters.LogEndState : Parameters.LogActiveState;
            TotalFilesTargeted = GetTotalFilesOfADirectory(saveJob.SourceDirectory);
            TotalFilesTargetedSize = GetTotalFilesSizeOfADirectory(saveJob.SourceDirectory);
            Progress = new SaveJobProgress(0, 0, "", "");
        }

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
