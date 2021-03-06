namespace EasySave.Model.Data.Job
{
    public interface IBackupJob
    {
        public string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string Type { get; set; }

        public void Execute();
    }
}
