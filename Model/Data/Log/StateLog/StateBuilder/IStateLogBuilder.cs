namespace testEasySave.Model.Data.Log.StateLog.StateBuilder
{
    public interface IStateLogBuilder
    {
        public IStateLog Log { get; set; }

        public void Reset();
        public void BuildSaveJobName(string name);
        public void BuildTimestamp();
        public void BuildState(bool active);
        public void BuildTotalFilesTargeted();
        public void BuildTotalFilesTargetedSize();
        public void BuildProgress();
    }
}
