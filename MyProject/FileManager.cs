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
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Directory doesn't exist! Directory created!");
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                Console.WriteLine("Directory found!");
            }
        }

        // Creates a file given the file name path
        public static void CreateFile(string fileName)
        {
            EnsureFolderExists();
            File.Create(folderPath + "/" + fileName);
            Console.WriteLine(folderPath + "/" + fileName + " created!");
        }

        // actually displays the content of the file name path
        private static void ActuallyDisplayFile(string filePath)
        {
            Console.Clear();
            int numDashes = 50;
            Console.WriteLine(new string('-', numDashes) + " Displaying: " + filePath + " " + new string('-', numDashes));
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContents = reader.ReadToEnd();
                Console.WriteLine(fileContents);
            }
            Console.WriteLine();
        }

        // prompts the user to select which pile to display, otherwise the user is warned
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

        public static void ActuallyDeleteFile(string filePathName)
        {
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

        public static void DeleteFile()
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    Console.WriteLine(file);
                }
                Console.Write("Enter file name (to delete): ");
                string input = Console.ReadLine();
                bool fileFound = false;
                foreach (string file in Directory.EnumerateFiles(folderPath))
                {
                    if (Path.GetFileName(file) == input)
                    {
                        fileFound = true;
                        ActuallyDeleteFile(folderPath + "/" + input);
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
    }
}