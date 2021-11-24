namespace testEasySave.Model.Data.ToolBox
{
    public class SaveJobProgress
    {
        public int TotalFileToCopy { get; }
        public double TotalFileSize { get; }
        public string ActualFileSourcePath { get; }
        public string ActualFileTargetPath { get; }

        public SaveJobProgress(int totalFileToCopy, double totalFileSize, string actualFileSourcePath, string actualFileTargetPath)
        {
            TotalFileToCopy = totalFileToCopy;
            TotalFileSize = totalFileSize;
            ActualFileSourcePath = actualFileSourcePath;
            ActualFileTargetPath = actualFileTargetPath;
        }
    }
}
