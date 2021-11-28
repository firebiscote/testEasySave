using System;
using testEasySave.Controller;

namespace testEasySave.View
{
    class MainView : IView
    {
        public IController Controller { get; set; }

        public MainView()
        {
            SayHello();
        }

        void IView.Start()
        {
            WaitForInstruction();
        }

        private void SayHello()
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string line in Parameters.Hello)
                Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WaitForInstruction()
        {
            Console.Write(Parameters.CommandIndent);
            string command = Console.ReadLine();
            Controller.Transmit(command);
        }

        public void DisplaySuccess(string message)
        {
            Display(message, ConsoleColor.Green);
        }

        public void DisplayError(string message)
        {
            Display(message, ConsoleColor.Red);
        }

        public void Display(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            WaitForInstruction();
        }
    }
}
