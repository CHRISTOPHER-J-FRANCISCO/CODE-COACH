using System;
using System.IO;

namespace CommandLineApp 
{

    public class FileManager 
    {

        private string fileName = "";

        public void setFileName(string newFileName) {

        }

        private string fileContents = "";

        public void setFileContents(string newFileContents) {

        }

        public String getFileContents() {
            return this.fileContents;
        }

        private static string folderPath = "SnippetsDirectory";

        private static void EnsureFolderExists()
        {
            if (!Directory.Exists(folderPath)) {
                Console.WriteLine("Directory doesn't exist! Directory created!");
                Directory.CreateDirectory(folderPath);
            } else {
                Console.WriteLine("Directory found!");
            }
        }

        public static void CreateFile(string fileName)
        {
            EnsureFolderExists();
            File.Create(folderPath + "/" + fileName);
            Console.WriteLine(folderPath + "/" + fileName + " created!");
        }

        public static void ActuallyDisplayFile(string filePath) {
            Console.Clear();
            int numDashes = 50;
            Console.WriteLine(new string('-', numDashes) + " " + filePath + " " + new string('-', numDashes));
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileContents = reader.ReadToEnd();
                Console.WriteLine(fileContents);
            }
        }

        public static void DisplayFile()
        {
            try
            {
                foreach(string file in Directory.EnumerateFiles(folderPath)) 
                {
                    Console.WriteLine(file);
                }
                Console.Write("Enter file name (to display): ");
                string input = Console.ReadLine();
                bool fileFound = false;
                foreach(string file in Directory.EnumerateFiles(folderPath))
                {
                    if (Path.GetFileName(file) == input)
                    {
                        fileFound = true;
                        ActuallyDisplayFile(folderPath + "/" + input);
                    }
                }
                if (!fileFound)
                {
                    Console.Write(input + " not found!");
                }
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("Error finding directory!");
            }
            catch(IOException)
            {
                Console.WriteLine("Error reading directory!");
            }
        }
    }
}