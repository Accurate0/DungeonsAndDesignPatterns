using System;

namespace DnDesignPattern.Views
{
    public class View
    {
        public void DisplayWarning(string str)
        {
            var yellow = "\u001b[33m";
            var reset = "\u001b[00m";
            Console.WriteLine($"\n{yellow}[warning]{reset} {str}\n");
        }

        public void DisplayError(string str)
        {
            var red = "\u001b[31m";
            var reset = "\u001b[00m";
            Console.Error.WriteLine($"\n{red}[error]{reset} {str}\n");
        }

        public void DisplayRed(string str)
        {
            var red = "\u001b[31m";
            var reset = "\u001b[00m";
            Console.WriteLine($"{red}{str}{reset}");
        }

        public void Display(string str)
        {
            Console.WriteLine(str);
        }

        public void DisplayMessage(string str)
        {
            var blue = "\u001b[34m";
            var reset = "\u001b[00m";
            Console.Error.WriteLine($"\n{blue}[message]{reset} {str}\n");
        }

        public void DisplayMessageNoNewline(string str)
        {
            var blue = "\u001b[34m";
            var reset = "\u001b[00m";
            Console.Error.WriteLine($"{blue}[message]{reset} {str}");
        }

        public void DisplayMenu(string str)
        {
            Console.WriteLine("--- Menu ---");
            Console.WriteLine(str);
        }

        public void DisplayMenu()
        {
            Console.WriteLine("--- Menu ---");
        }

        public void DisplayMenuReturn()
        {
            DisplayMessage("Returning to previous menu..");
        }
    }
}
