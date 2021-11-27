using System;
using System.IO;

namespace testEasySave.Model.Data.ToolBox
{
    public class FileEventArgs : EventArgs
    {
        public FileInfo File{ get; }

        public FileEventArgs(FileInfo file)
        {
            File = file;
        }
    }
}
