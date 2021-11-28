using System;

namespace testEasySave.Exceptions
{
    public class NotEnoughSpaceException : Exception
    {
        public NotEnoughSpaceException() { }
        public NotEnoughSpaceException(string message) : base(message) { }
    }
}
