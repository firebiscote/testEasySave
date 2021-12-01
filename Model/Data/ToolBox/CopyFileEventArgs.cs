using System;
using System.IO;

namespace EasySave.Model.Data.ToolBox
{
    public class CopyFileEventArgs : EventArgs
    {
        public DateTime Start { get; }
        public FileInfo File { get; }
        public string[] RemainingFiles { get; }

        public CopyFileEventArgs(DateTime start, FileInfo file, string[] remainingFiles)
        {
            Start = start;
            File = file;
            RemainingFiles = remainingFiles;
        }
    }
}
