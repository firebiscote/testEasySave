namespace testEasySave.Model.Data.Job
{
    public interface ISaveJob
    {
        public string Name { get; }
        public string SourceDirectory { get; }
        public string TargetDirectory { get; }
        public string Type { get; }

        public void Execute();
    }
}
