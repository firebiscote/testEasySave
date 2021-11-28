using System;

namespace testEasySave.Exceptions
{
    public class ShowException : Exception
    {
        public ShowException() { }
        public ShowException(string message) : base(message) { }
    }
}
