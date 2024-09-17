using System;
using System.IO;

namespace CommandLineApp
{
    class CodeCoach
    {
        public static void GuideStudent(string filePath)
        {
            // read the file 
            using (StreamReader reader = new StreamReader(filePath))
            {
                // file contents to char arr
                char[] chars = reader.ReadToEnd().ToCharArray();
                // save the true length of the char arr for % calc
                var trueLength = chars.Length;
                // index the user is at
                var coachingIndex = 0;
                // save the users input
                string totalUserInput = "";
                // iterate through every index
                while (coachingIndex < chars.Length)
                {
                    // Remove // comments
                    if (chars[coachingIndex] == '/' && chars[coachingIndex + 1] == '/')
                    {

                        while (chars[coachingIndex] != '\n')
                        {
                            totalUserInput += chars[coachingIndex++];
                        }
                        totalUserInput += chars[coachingIndex++];
                        PrintHeader(filePath + ' ' + Math.Round(totalUserInput.Length * 100.0 / trueLength) + "%");
                        Console.Write(totalUserInput);
                        continue;
                    }
                    // Have bogus input ready
                    ConsoleKeyInfo userInput = Console.ReadKey(true);  
                    // Store if its either an enter key or a char key
                    if (userInput.KeyChar == '\n')
                    {
                        Console.WriteLine("Potato");
                    }
                    bool isEnterKey = userInput.Key == ConsoleKey.Enter && chars[coachingIndex] == '\n';
                    bool isAKeyChar = userInput.KeyChar == chars[coachingIndex];
                    // Interpret both
                    if (isAKeyChar || isEnterKey)
                    {
                        // Print header
                        PrintHeader(filePath + ' ' + Math.Round(totalUserInput.Length * 100.0 / trueLength) + "%");
                        // Add to input
                        if (isEnterKey) {
                            totalUserInput += '\n';
                        } 
                        else if (isAKeyChar)
                        {
                            totalUserInput += userInput.KeyChar;
                        } 
                        Console.Write(totalUserInput);
                        // Move onto next char
                        coachingIndex++;
                    }
                }
                // Prints user header when user complete
                PrintHeader(filePath + " 100%");
                // Prints entire user input
                Console.Write(totalUserInput);

            }
            // print a space line
            Console.WriteLine("");
        }

        // Prints header
        public static void PrintHeader(string filePath)
        {
            Console.Clear();
            int numDashes = 50;
            Console.WriteLine(new string('-', numDashes) + " Coaching: " + filePath + " " + new string('-', numDashes));
        }

        // Start coaching the student
        public static void StartCoaching()
        {
            string filePath = FileManager.GetFileNamePath();
            PrintHeader(filePath);
            GuideStudent(filePath);
        }

    }
}

