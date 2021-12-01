namespace EasySave.Model.Data.Log.StateLog.StateBuilder
{
    public interface IStateLogBuilder
    {
        public IStateLog Log { get; set; }

        public void BuildSaveJobName(string name);
        public void BuildTimestamp();
        public void BuildState();
        public void BuildTotalTargetedFiles(string sourceDirectory);
        public void BuildTotalTargetedFilesSize();
        public void BuildProgress(string[] remainingFiles, string sourceFile, string targetFile);
    }
}
