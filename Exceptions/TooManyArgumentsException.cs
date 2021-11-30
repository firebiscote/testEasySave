using System;

namespace testEasySave.Exceptions
{
    public class TooManyArgumentsException : Exception
    {
        public TooManyArgumentsException() { }
        public TooManyArgumentsException(string message) : base(message) { }
    }
}
