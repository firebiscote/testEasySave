using System;

namespace testEasySave.Exceptions
{
    public class CommandNotExistException : Exception
    {
        public CommandNotExistException() { }
        public CommandNotExistException(string message) : base(message) { }
    }
}
