using System;

namespace EasySave.Exceptions
{
    public class TooManyArgumentsException : Exception
    {
        public TooManyArgumentsException() { }
        public TooManyArgumentsException(string message) : base(message) { }
    }
}
