namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb  = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = string.Empty;

                int counter = 0;

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (counter % 2 == 0)
                    {
                        string replacedSymbols = ReplacedSymbols(line);
                        string reversedWords = ReversedWords(replacedSymbols);
                        sb.Append(reversedWords);
                    }

                    counter++;
                }
            }

            return sb.ToString();
        }

        private static string ReversedWords(string replacedSymbols)
        {
            string[] reversedWords = replacedSymbols
                .Split(' ')
                .Reverse()
                .ToArray();

            return string.Join(" ", reversedWords);
        }

        private static string ReplacedSymbols(string line)
        {
            StringBuilder sb = new StringBuilder(line);

            string[] symbolsToReplace = { "-", ", ", ". ", "! ", "? " };

            foreach (var symbol in symbolsToReplace)
            {
                sb.Replace(symbol, "@");
            }

            return sb.ToString();
        }
    }
}
