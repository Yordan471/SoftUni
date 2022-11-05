using System;
using System.Collections.Generic;

namespace ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToAFile = Console.ReadLine();

            int lastIndexBacklash = pathToAFile.LastIndexOf('\\');
            int lastIndexOfADot = pathToAFile.LastIndexOf('.');
            int diffIndex = lastIndexOfADot - lastIndexBacklash;
            string name = pathToAFile.Substring(lastIndexBacklash + 1 , diffIndex - 1);
            string extension = pathToAFile.Substring(lastIndexOfADot + 1);

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
