﻿using System;
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Yellow;
            foreach (string line in Parameters.Hello)
                Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void WaitForInstruction()
        {
            Console.Write(Parameters.CommandIndent);
            string command = Console.ReadLine();
            this.Controller.Transmit(command);
        }

        public void Display(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            WaitForInstruction();
        }

        public void DisplaySuccess(string message)
        {
            Display(message, ConsoleColor.Green);
        }

        public void DisplayError(string message)
        {
            Display(message, ConsoleColor.Red);
        }
    }
}
