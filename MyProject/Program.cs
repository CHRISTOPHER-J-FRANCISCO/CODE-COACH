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
            string availableCommands = "Available commands: quit, holy-cow, create-file, display-file, edit-file, delete-file, code-coach";
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
                        FileManager.CreateFile(input);
                        break;
                    case "display-file":
                        FileManager.DisplayFile();
                        break;
                    case "edit-file":
                        FileManager.EditFile();
                        break;
                    case "delete-file":
                        FileManager.DeleteFile();
                        break;
                    case "code-coach":
                        break;
                    default:
                        Clear();
                        break;
                }
            }

        }
    }
}