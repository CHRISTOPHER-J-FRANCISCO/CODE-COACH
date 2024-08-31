using System;

namespace CommandLineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Christopher J. Francisco's command-line app!");
            string availableCommands = "Available commands: help, quit, holy-cow";
            string holy_cow = @"
 ________
< MOOOO! >
 ‾‾‾‾‾‾‾‾\     ╭───╮
          \    ╰───╯
           \   ^__^
            \  (oo)\_______
               (__)\       )\/\
                   ||----w |
                   ||     ||";
            Console.WriteLine(availableCommands);
            while (true)
            {
                
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "help":
                        Console.WriteLine(availableCommands);
                        break;
                    case "quit":
                        Console.WriteLine("x_x");
                        return;
                    case "holy-cow":
                        Console.WriteLine(holy_cow);
                        break;
                    default:
                        Console.WriteLine("Type 'help'.");
                        break;
                }
            }

        }
    }
}