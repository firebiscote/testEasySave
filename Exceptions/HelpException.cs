using System;

namespace testEasySave.Exceptions
{
    public class HelpException : Exception
    {
        public HelpException() { }
        public HelpException(string message) : base(message) { }
    }
}
