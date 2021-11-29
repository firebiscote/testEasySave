using System;

namespace testEasySave.Exceptions
{
    public class SaveJobTypeNotImplementedException : Exception
    {
        public SaveJobTypeNotImplementedException() { }
        public SaveJobTypeNotImplementedException(string message) : base(message) { }
    }
}
