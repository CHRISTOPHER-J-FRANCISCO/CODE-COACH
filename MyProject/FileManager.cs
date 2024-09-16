using System;
using System.IO;

namespace CommandLineApp
{
    public class FileManager
    {
        private static readonly string folderPath = "SnippetsDirectory";

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
            // Ensure the storage folder exists
            EnsureFolderExists();
            Console.Write("Enter file name: ");
            // Get file name
             string fileName = Console.ReadLine();
            // Ensures the fileName is not null or empty
            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("File name cannot be null or empty.");
                return;
            }
            // Create file path
            string filePath = Path.Combine(folderPath, fileName);
            // Attempts to create file
            try
            {
                // Using ensures the File created is closed
                using(File.Create(filePath)) {};
                // Let the user know the file has been created
                Console.WriteLine(filePath + " created!");
            }
            catch (Exception ex)
            {
                // Let the user know the file has not been created
                Console.WriteLine("Failed to create file: " + ex.Message);
            }
        }

        // Display file given path name provided by the user
        public static void DisplayFile()
        {
            // Get file name path provided by the user
            string filePath = GetFileNamePath();
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

        // Edit file given path name provided by the user
        public static void EditFile()
        {
            // Get file name path provided by the user
            string filePath = GetFileNamePath();
            // Display content header 
            Console.Clear();
            int numDashes = 50;
            // Display content file
            try
            {
                string fileContents = File.ReadAllText(filePath);
                // Display editing file
                while (true)
                {
                    // Display instructions for editing the file and the header
                    Console.Clear();
                    Console.WriteLine("Type changes, backspace to delete, and esc to save.!");
                    Console.WriteLine(new string('-', numDashes) + " Editing: " + filePath + " " + new string('-', numDashes));
                    // Display file contents
                    Console.Write(fileContents);
                    // Get user input
                    var userInput = Console.ReadKey();
                    // If there's something to delete
                    if (userInput.Key == ConsoleKey.Backspace && fileContents.Length > 0)
                    {
                        // Delete the latest character
                        fileContents = fileContents.Substring(0, fileContents.Length - 1);
                    }
                    // If the key wasn't enter or escape the user had something to enter
                    else if (userInput.Key != ConsoleKey.Enter && userInput.Key != ConsoleKey.Escape)
                    {
                        fileContents += userInput.KeyChar;
                    }
                    // If the key was enter add a next line
                    else if (userInput.Key == ConsoleKey.Enter)
                    {
                        fileContents += "\n";
                    }
                    // If the key was escape stop editing
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
            catch (Exception exce)
            {
                Console.WriteLine("Error editing file: " + exce.Message);
            }
        }

        // delete file given name path provided by the user
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
                // Make sure input is not null or empty
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("File name cannot be null or empty.");
                    return "";
                }
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