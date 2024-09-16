using System;
using System.IO;

namespace CommandLineApp
{
    /*
        Fix: Behave differenly from different kind of spaces
    */
    class CodeCoach {
         /** save the contents of the file, 
                whatever is next that is a character of some sort 
                prompt the user for it without showing it 
                until the user types it, 
                if the user types incorrectly dont save/show it
                if its a space or nextline just show it
        **/
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
                    // save input 
                    System.ConsoleKeyInfo userInput = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
                    // if input is not a whitespace, initially false
                    if (!Char.IsWhiteSpace(chars[coachingIndex]))
                    {
                        userInput = Console.ReadKey(true);
                    }
                    // if the key matches the file char
                    if (userInput.KeyChar == chars[coachingIndex])
                    {
                        // print header
                        PrintHeader(filePath + ' ' + Math.Round(totalUserInput.Length * 100.0 / trueLength) + "%");
                        // print latest user input
                        totalUserInput += userInput.KeyChar;
                        Console.Write(totalUserInput);
                        // move onto next char
                        coachingIndex++;
                    }
                    // is a white space 
                    else if (Char.IsWhiteSpace(chars[coachingIndex]))
                    {
                        // add white space to user input // basically dont waste time learning
                        totalUserInput += ConsoleKey.Enter;
                    }
                }
                // prints user header
                PrintHeader(filePath + " 100%");
                // prints entire user input
                Console.Write(totalUserInput);

            }
            // print a space line
            Console.WriteLine("");
        }

        // prints header
        public static void PrintHeader(string filePath)
        {
            Console.Clear();
            int numDashes = 50;
            Console.WriteLine(new string('-', numDashes) + " Coaching: " + filePath + " " + new string('-', numDashes));
        }
        
        // start coaching the student
        public static void StartCoaching(string filePath)
        {
            PrintHeader(filePath);
            GuideStudent(filePath);
        }

    }
}

