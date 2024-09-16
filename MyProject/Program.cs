using System;

namespace CommandLineApp
{
    class Program
    {
        // introduce the user with a welcome
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Christopher J. Francisco's command-line app!");
            // instructions
            string availableCommands = "Available commands: quit, holy-cow, create-file, display-file, edit-file, delete-file, code-coach\nEnter a command: ";
            // holy cow
            string holy_cow = @"
 ________
< MOOOO! >
 --------\     /---\
          \    \---/
           \   ^__^
            \  (oo)\_______
               (__)\       )\/\
                   ||----w |
                   ||     ||";

            // run program loop
            while (true)
            {
                // print the available commands
                Console.Write(availableCommands);
                // prompt user command
                string input = Console.ReadLine();
                // Make sure input is not null or empty
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("User command cannot be null or empty.");
                    continue;
                }
                // identify action for user command
                switch (input.ToLower())
                {
                    // quit program
                    case "quit":
                        Console.Clear();
                        Console.WriteLine("x_x");
                        return;
                    // print a holy cow
                    case "holy-cow":
                        Console.Clear();
                        Console.WriteLine(holy_cow);
                        break;
                    // allow user to create a file
                    case "create-file":
                        FileManager.CreateFile();
                        break;
                    // allow user to display a file
                    case "display-file":
                        FileManager.DisplayFile();
                        break;
                    // allow user to edit a file
                    case "edit-file":
                        FileManager.EditFile();
                        break;
                    // allow user to delete a file
                    case "delete-file":
                        FileManager.DeleteFile();
                        break;
                    // coach user on a file
                    case "code-coach":
                        CodeCoach.StartCoaching();
                        break;
                    // just clear the console
                    default:
                        Console.Clear();
                        break;
                }
            }

        }
    }
}