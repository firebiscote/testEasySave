using System;
using EasySave.Controller;

namespace EasySave.View
{
    public interface IView
    {
        public IController Controller { get; set; }

        public void Start() { }
        public void Display(string message, ConsoleColor color);
        public void DisplaySuccess(string message) { }
        public void DisplayError(string message) { }
    }
}
