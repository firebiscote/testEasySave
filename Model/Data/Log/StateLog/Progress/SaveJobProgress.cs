namespace testEasySave.Model.Data.Log.StateLog.Progress
{
    public class SaveJobProgress
    {
        public int TotalFilesToCopy { get; set; }
        public double TotalFilesToCopySize { get; set; }
        public string ActualSourceFileName { get; set; }
        public string ActualTargetFileName { get; set; }

        public SaveJobProgress(int totalFileToCopy, double totalFileSize, string actualFileSourcePath, string actualFileTargetPath)
        {
            TotalFilesToCopy = totalFileToCopy;
            TotalFilesToCopySize = totalFileSize;
            ActualSourceFileName = actualFileSourcePath;
            ActualTargetFileName = actualFileTargetPath;
        }
    }
}
