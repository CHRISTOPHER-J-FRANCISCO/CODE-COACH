using System;
using System.IO;

namespace CommandLineApp
{
    class CodeCoach {
        
        public static void startCoaching(string filePath)
        {
            Console.Clear();
            int numDashes = 50;
            Console.WriteLine(new string('-', numDashes) + " Coaching: " + filePath + " " + new string('-', numDashes));
        }
    }
}

