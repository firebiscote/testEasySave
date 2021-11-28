using System;
using System.IO;
using testEasySave.Model.Data.Log.StateLog.Progress;

namespace testEasySave.Model.Data.Log.StateLog.StateBuilder
{
    public class StateLogBuilder : IStateLogBuilder
    {
        public IStateLog Log { get; set; }
        private string[] targetedFiles;
        private int totalTargetedFiles;
        private long totalTargetedFilesSize;
        private string[] remainingFiles;
        private int totalRemainingFiles;
        private long totalRemainingFilesSize;

        public void Reset()
        {
            Log = new StateLog();
            totalTargetedFiles = -1;
            totalTargetedFilesSize = -1;
            totalRemainingFiles = -1;
            totalRemainingFilesSize = -1;
        }

        public void BuildSaveJobName(string name)
        {
            Log.SaveJobName = name;
        }

        public void BuildTimestamp()
        {
            Log.Timestamp = DateTime.Now.ToString(Parameters.LogTimestampFormat);
        }

        public void BuildState(string state)
        {
            Log.State = state;
        }

        public void BuildTotalTargetedFiles(string sourceDirectory)
        {
            if (totalTargetedFiles == -1)
            {
                targetedFiles = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);
                totalTargetedFiles = targetedFiles.Length;
            }
            Log.TotalTargetedFiles = totalTargetedFiles;
        }

        public void BuildTotalTargetedFilesSize()
        {
            if (totalTargetedFilesSize == -1)
            {
                totalTargetedFilesSize++;
                foreach (string file in targetedFiles)
                    totalTargetedFilesSize += new FileInfo(file).Length;
            }
            Log.TotalTargetedFilesSize = totalTargetedFilesSize;
        }

        public void BuildProgress(string[] remainingFiles, string sourceFile, string targetFile)
        {
            this.remainingFiles = remainingFiles;
            Log.Progress = new SaveJobProgress();
            BuildProgressTotalFilesToCopy();
            BuildProgressTotalFilesToCopySize();
            BuildProgressActualSourceFileName(sourceFile);
            BuildProgressActualTargetFileName(targetFile);
        }

        private void BuildProgressTotalFilesToCopy()
        {
            if (totalRemainingFiles == -1)
                totalRemainingFiles = remainingFiles.Length;
            Log.Progress.TotalFilesToCopy = totalRemainingFiles;
        }

        private void BuildProgressTotalFilesToCopySize()
        {
            if (totalRemainingFilesSize == -1)
            {
                totalRemainingFilesSize++;
                foreach (string file in remainingFiles)
                    totalRemainingFilesSize += new FileInfo(file).Length;
            }
            Log.Progress.TotalFilesToCopySize = totalRemainingFilesSize;
        }

        private void BuildProgressActualSourceFileName(string sourceFile)
        {
            Log.Progress.ActualSourceFileName = sourceFile;
        }

        private void BuildProgressActualTargetFileName(string targetFile)
        {
            Log.Progress.ActualTargetFileName = targetFile;
        }
    }
}
