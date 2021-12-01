using System;

namespace EasySave.Exceptions
{
    public class HelpException : Exception
    {
        public HelpException() { }
        public HelpException(string message) : base(message) { }
    }
}
