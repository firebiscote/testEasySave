using System;

namespace EasySave.Exceptions
{
    public class BackupJobTypeNotImplementedException : Exception
    {
        public BackupJobTypeNotImplementedException() { }
        public BackupJobTypeNotImplementedException(string message) : base(message) { }
    }
}
