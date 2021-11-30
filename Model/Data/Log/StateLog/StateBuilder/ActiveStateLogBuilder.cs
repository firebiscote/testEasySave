using System.IO;
using testEasySave.Model.Data.Log.StateLog.Progress;

namespace testEasySave.Model.Data.Log.StateLog.StateBuilder
{
    public class ActiveStateLogBuilder : AbstractStateLogBuilder
    {
        private string[] targetedFiles;
        private string[] remainingFiles;

        public ActiveStateLogBuilder()
        {
            Log = new StateLog();
        }

        public override void BuildState()
        {
            Log.State = Parameters.LogActiveState;
        }

        public override void BuildTotalTargetedFiles(string sourceDirectory)
        {
            targetedFiles = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);
            Log.TotalTargetedFiles = targetedFiles.Length;
        }

        public override void BuildTotalTargetedFilesSize()
        {
            Log.TotalTargetedFilesSize = 0;
            foreach (string file in targetedFiles)
                Log.TotalTargetedFilesSize += new FileInfo(file).Length;
        }

        public override void BuildProgress(string[] remainingFiles, string sourceFile, string targetFile)
        {
            this.remainingFiles = remainingFiles;
            Log.Progress = new SaveJobProgress();
            BuildProgressTotalFilesToCopy();
            BuildProgressTotalFilesToCopySize();
            BuildProgressActualSourceFileName(sourceFile);
            BuildProgressActualTargetFileName(targetFile);
        }

        protected override void BuildProgressTotalFilesToCopy()
        {
            Log.Progress.TotalFilesToCopy = remainingFiles.Length;
        }

        protected override void BuildProgressTotalFilesToCopySize()
        {
            Log.Progress.TotalFilesToCopySize = 0;
            foreach (string file in remainingFiles)
                Log.Progress.TotalFilesToCopySize += new FileInfo(file).Length;
        }

        protected override void BuildProgressActualSourceFileName(string sourceFile)
        {
            Log.Progress.ActualSourceFileName = sourceFile;
        }

        protected override void BuildProgressActualTargetFileName(string targetFile)
        {
            Log.Progress.ActualTargetFileName = targetFile;
        }
    }
}
