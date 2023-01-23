namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            // read all lines from the file
            string[] lines = File.ReadAllLines(inputFilePath);

            // read one line from lines and add line plus number
            for (int i = 0; i < lines.Length; i++)
            {
                // Take count of all letters in line of i
                int countLetters = lines[i].Count(ch => char.IsLetter(ch));

                // Take count of all punctuation symbols
                int countSymbols = lines[i].Count(ch => char.IsPunctuation(ch));

                sb.Append($"line {i + 1}: {lines[i]} ({countLetters})({countSymbols})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
