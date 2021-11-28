using System;
using System.IO;

namespace testEasySave.Model.Data.ToolBox
{
    public class CopyFileEventArgs : EventArgs
    {
        public DateTime Start { get; }
        public FileInfo File { get; }

        public CopyFileEventArgs(DateTime start, FileInfo file)
        {
            Start = start;
            File = file;
        }
    }
}
