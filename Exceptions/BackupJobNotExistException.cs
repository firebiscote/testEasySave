using System;

namespace testEasySave.Exceptions
{
    public class BackupJobNotExistException : Exception
    {
        public BackupJobNotExistException() { }
        public BackupJobNotExistException(string message) : base(message) { }
    }
}
