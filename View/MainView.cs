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
            Console.WriteLine("  ______                   _____                   __   ___   ___");
            Console.WriteLine(" |  ____|                 / ____|                 /_ | / _ \\ / _ \\ ");
            Console.WriteLine(" | |__   __ _ ___ _   _  | (___   __ ___   _____   | || | | | | | |");
            Console.WriteLine(" |  __| / _` / __| | | |  \\___ \\ / _` \\ \\ / / _ \\  | || | | | | | |");
            Console.WriteLine(" | |___| (_| \\__ \\ |_| |  ____) | (_| |\\ V /  __/  | || |_| | |_| |");
            Console.WriteLine(" |______\\__,_|___/\\__, | |_____/ \\__,_| \\_/ \\___|  |_(_)___(_)___/ ");
            Console.WriteLine("                   __/ |");
            Console.WriteLine("                  |___/ \n\n");
        }

        public void WaitForInstruction()
        {
            Console.Write("=> ");
            string command = Console.ReadLine();
            this.Controller.Transmit(command);
        }

        public void DisplaySuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            WaitForInstruction();
        }

        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            WaitForInstruction();
        }
    }
}
