using System;
using EasySave.Controller;

namespace EasySave.View
{
    public class MainView : IView
    {
        public IController Controller { get; set; }

        public MainView()
        {
            SayHello();
            SayIntroduction();
        }

        public void Start()
        {
            ShowAllSaveJobs();
            WaitForInstruction();
        }

        private void SayHello()
        {
            foreach (string line in Parameters.Hello)
                Console.WriteLine(line);
        }

        private void SayIntroduction()
        {
            Console.WriteLine(Parameters.Introduction);
        }

        private void ShowAllSaveJobs()
        {
            Controller.Transmit(Parameters.Show);
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
