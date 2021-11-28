namespace testEasySave.Model.Data.Log.StateLog.Progress
{
    public class SaveJobProgress
    {
        public int TotalFilesToCopy { get; set; }
        public long TotalFilesToCopySize { get; set; }
        public string ActualSourceFileName { get; set; }
        public string ActualTargetFileName { get; set; }

        public SaveJobProgress() { }
    }
}
