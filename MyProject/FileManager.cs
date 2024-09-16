using System;
using System.IO;

namespace CommandLineApp
{
    public class FileManager
    {
        private static string folderPath = "SnippetsDirectory";

        // Ensures the folder exists, if not creates the folder path
        private static void EnsureFolderExists()
        {
            // If the storage folder doesn't exist let the user know and create it
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Directory doesn't exist! Directory created!");
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                // If the storage folder exists, let the user know
                Console.WriteLine("Directory found!");
            }
        }

        // Creates a file given the file name path
        public static void CreateFile()
        {
            // Prompot the file name
            Console.Clear();
            Console.Write("Enter file name: ");
            string fileName = Console.ReadLine();
            // Ensure the storage folder exists
            EnsureFolderExists();
            // Let the user know the file has been created
            File.Create(folderPath + "/" + fileName);
            Console.WriteLine(folderPath + "/" + fileName + " created!");
        }

        // Actually displays the content of the file name path
        private static void ActuallyDisplayFile(string filePath)
        {
            // Display the header
            Console.Clear();
            int numDashes = 50;
            Console.WriteLine(new string('-', numDashes) + " Displaying: " + filePath + " " + new string('-', numDashes));
            // Print the contents of the selected file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContents = reader.ReadToEnd();
                Console.WriteLine(fileContents);
            }
            Console.WriteLine();
        }

        // Prompts the user to select which pile to display, otherwise the user is warned
        public static void DisplayFile()
        {

            try
            {
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    Console.WriteLine(file);
                }
                Console.Write("Enter file name (to display): ");
                string input = Console.ReadLine();
                bool fileFound = false;
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    if (Path.GetFileName(file) == input)
                    {
                        fileFound = true;
                        ActuallyDisplayFile(folderPath + "/" + input);
                    }
                }
                if (!fileFound)
                {
                    Console.WriteLine(input + " not found!");
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error finding directory!");
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading directory!");
            }
        }

        private static void ActuallyEditFile(string filePath)
        {
            // Display content header 
            Console.Clear();
            int numDashes = 50;
            // Display content file
            string fileContents = File.ReadAllText(filePath);
            // Display editing file
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type changes, backspace to delete, and esc to save.!");
                Console.WriteLine(new string('-', numDashes) + " Editing: " + filePath + " " + new string('-', numDashes));
                Console.Write(fileContents);
                var userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.Backspace && fileContents.Length > 0)
                {
                    fileContents = fileContents.Substring(0, fileContents.Length - 1);
                }
                else if (userInput.Key != ConsoleKey.Enter && userInput.Key != ConsoleKey.Escape)
                {
                    fileContents += userInput.KeyChar;
                }
                else if (userInput.Key == ConsoleKey.Enter)
                {
                    fileContents += "\n";
                }
                else if (userInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
            // Save editing file
            Console.WriteLine();
            Console.WriteLine(filePath + " saved!");
            File.WriteAllText(filePath, fileContents);
        }

        // prompts the user which file to edit otherwise the user is warned
        public static void EditFile()
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    Console.WriteLine(file);
                }
                Console.Write("Enter file name (to edit): ");
                string input = Console.ReadLine();
                bool fileFound = false;
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    if (Path.GetFileName(file) == input)
                    {
                        fileFound = true;
                        ActuallyEditFile(folderPath + "/" + input);
                    }
                }
                if (!fileFound)
                {
                    Console.WriteLine(input + " not found!");
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error finding directory!");
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading directory!");
            }
        }

        public static void DeleteFile()
        {
            string filePathName = GetFileNamePath();
            try
            {
                File.Delete(filePathName);
                Console.WriteLine(filePathName + " deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting file: " + ex.Message);
            }
        }

        // Returns the path of the available files based on user input selection - FIX USE ONLY 2 RETURNS
        public static string GetFileNamePath()
        {
            try
            {
                // Iterate through the storage directory to print each file within - FIX CONVERT TO O(1)
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    Console.WriteLine(file);
                }
                // Prompt user
                Console.Write("Enter file name (to retrieve): ");
                // Obtain input
                string input = Console.ReadLine();
                // Determine if the file was found - FIX CONVERT TO O(1)
                bool fileFound = false;
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    if (Path.GetFileName(file) == input)
                    {
                        fileFound = true;
                        return folderPath + "/" + input;
                    }
                }
                // if file wasn't found return literally nothing
                if (!fileFound)
                {
                    return "";
                }
            }
            // let the user know the storage folder doesn't exist
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error finding directory!");
                return "";
            }
            // let the user know it had toruble reading storage directory
            catch (IOException)
            {
                Console.WriteLine("Error reading directory!");
                return "";
            }
            // return nothing literally
            return "";
        }
    }
}