using System;

namespace CommandLineApp
{
    class Program
    {
        static void Clear() {
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Clear();
            Console.WriteLine("Welcome to Christopher J. Francisco's command-line app!");
            string availableCommands = "Available commands: quit, holy-cow, create-file, display-file, edit-file";
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
            while (true)
            {
                Console.WriteLine(availableCommands);
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "quit":
                        Clear();
                        Console.WriteLine("x_x");
                        return;
                    case "holy-cow":
                        Clear();
                        Console.WriteLine(holy_cow);
                        break;
                    case "create-file":
                        Clear();
                        Console.Write("Enter file name: ");
                        input = Console.ReadLine();
                        CommandLineApp.FileManager.CreateFile(input);
                        break;
                    case "display-file":
                        CommandLineApp.FileManager.DisplayFile();
                        break;
                    case "edit-file":
                        CommandLineApp.FileManager.EditFile();
                        break;
                    case "delete-file":
                        break;
                    default:
                        Clear();
                        break;
                }
            }

        }
    }
}