namespace EasySave.Model.Data.Log.StateLog.Progress
{
    public class BackupJobProgress
    {
        public int TotalFilesToCopy { get; set; }
        public long TotalFilesToCopySize { get; set; }
        public string ActualSourceFileName { get; set; }
        public string ActualTargetFileName { get; set; }

        public BackupJobProgress() { }
    }
}
