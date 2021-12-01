using System;

namespace EasySave.Exceptions
{
    public class NotImplementedLanguageException : Exception
    {
        public NotImplementedLanguageException() { }
        public NotImplementedLanguageException(string message) : base(message) { }
    }
}
