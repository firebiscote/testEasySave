using System;

namespace EasySave.Model.Data.Log.StateLog.StateBuilder
{
    public abstract class AbstractStateLogBuilder : IStateLogBuilder
    {
        public IStateLog Log { get; set; }

        public void BuildSaveJobName(string name)
        {
            Log.SaveJobName = name;
        }

        public void BuildTimestamp()
        {
            Log.Timestamp = DateTime.Now.ToString(Parameters.LogTimestampFormat);
        }

        public abstract void BuildState();
        public virtual void BuildTotalTargetedFiles(string sourceDirectory) { }
        public virtual void BuildTotalTargetedFilesSize() { }
        public virtual void BuildProgress(string[] remainingFiles, string sourceFile, string targetFile) { }
        protected virtual void BuildProgressTotalFilesToCopy() { }
        protected virtual void BuildProgressTotalFilesToCopySize() { }
        protected virtual void BuildProgressActualSourceFileName(string sourceFile) { }
        protected virtual void BuildProgressActualTargetFileName(string targetFile) { }
    }
}
