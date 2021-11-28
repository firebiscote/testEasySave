using System;

namespace testEasySave.Exceptions
{
    class NotImplementedLanguageException : Exception
    {
        public NotImplementedLanguageException() { }
        public NotImplementedLanguageException(string message) : base(message) { }
    }
}
