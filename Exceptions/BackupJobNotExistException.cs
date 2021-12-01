using System;

namespace EasySave.Exceptions
{
    public class BackupJobNotExistException : Exception
    {
        public BackupJobNotExistException() { }
        public BackupJobNotExistException(string message) : base(message) { }
    }
}
