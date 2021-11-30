using System;

namespace testEasySave.Exceptions
{
    public class BackupJobTypeNotImplementedException : Exception
    {
        public BackupJobTypeNotImplementedException() { }
        public BackupJobTypeNotImplementedException(string message) : base(message) { }
    }
}
