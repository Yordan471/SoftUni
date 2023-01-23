namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            Dictionary<string, int> wordsAndCount = new
                Dictionary<string, int>();

            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath, wordsAndCount);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath, 
            Dictionary<string, int> wordsAndCount)
        {
            using (StreamReader readerWords = new StreamReader(wordsFilePath))
            {
                string word = string.Empty;

                while ((word = readerWords.ReadLine()) != null)
                {
                    string[] words = word.Split(' ');

                    foreach (string wrd in words)
                    {
                        wordsAndCount.Add(wrd, 0);
                    }                 
                }
            }

            using (StreamReader readerText = new StreamReader(textFilePath))
            {
                string line = string.Empty;

                while ((line = readerText.ReadLine()) != null)
                {
                    foreach (var word in wordsAndCount)
                    {
                       
                        if (line.Contains(word.Key))
                        {
                            wordsAndCount[word.Key] += 1;
                        }
                    }
                        
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordsAndCount)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
