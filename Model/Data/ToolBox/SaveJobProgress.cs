namespace testEasySave.Model.Data.ToolBox
{
    public class SaveJobProgress
    {
        public int TotalFilesToCopy { get; }
        public double TotalFilesToCopySize { get; }
        public string ActualSourceFileName { get; }
        public string ActualTargetFileName { get; }

        public SaveJobProgress(int totalFileToCopy, double totalFileSize, string actualFileSourcePath, string actualFileTargetPath)
        {
            TotalFilesToCopy = totalFileToCopy;
            TotalFilesToCopySize = totalFileSize;
            ActualSourceFileName = actualFileSourcePath;
            ActualTargetFileName = actualFileTargetPath;
        }
    }
}
