using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Santa_s_Little_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int subtractNuber = int.Parse(Console.ReadLine());

            string command = string.Empty;
            List<string> names = new List<string>();

            string messagePattern = @"(([^@\-!:>]+)?@(?<name>[A-Za-z]+)[^@\-!:>]+!(?<behavior>[GN])!([^@\-!:>]+)?)";

            Regex regexFullMessage = new Regex(messagePattern);

            while ((command = Console.ReadLine()) != "end")
            {
                string encryptedInfo = command;
                StringBuilder decryptedInfo= new StringBuilder();

                foreach (char ch in encryptedInfo)
                {
                    int ASCIInum = ch;
                    ASCIInum -= subtractNuber;

                    decryptedInfo.Append((char)ASCIInum);               
                }

                string message = decryptedInfo.ToString();
                Match matchFullMessage = regexFullMessage.Match(message);


                string fullMessage = matchFullMessage.Groups[0].Value;
                string name = matchFullMessage.Groups["name"].Value;
                string behaviour = matchFullMessage.Groups["behavior"].Value;

                int startIndexN = fullMessage.IndexOf(name);
                int startIndexB = fullMessage.IndexOf(behaviour);

                if (startIndexN < startIndexB && matchFullMessage.Success)
                {
                    if (behaviour == "G")
                    {
                        names.Add(name);
                    }                   
                }                
            }

            if (names.Count> 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, names));
            }          
        }
    }
}
