using System;

namespace EasySave.Exceptions
{
    public class CommandNotExistException : Exception
    {
        public CommandNotExistException() { }
        public CommandNotExistException(string message) : base(message) { }
    }
}
