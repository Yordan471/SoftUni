using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string command = string.Empty;
            string patter = @"[\w]";

            Match match;
            int sum = 0;
            string name = string.Empty;
            Dictionary<string, int> nameAndSum = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "end of race")
            {
                match = Regex.Match(command, patter);

                if (match.Success)
                {
                    char[] chars = command.ToCharArray();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (char.IsDigit(chars[i]))
                        {
                            sum += int.Parse(chars[i].ToString());
                        }
                        else if (char.IsLetter(chars[i]))
                        {
                            name += chars[i];
                        }
                    }
                }

                if (!nameAndSum.ContainsKey(name))
                {
                    nameAndSum.Add(name, 0);
                }

                nameAndSum[name] += sum;
                sum = 0;
                name = string.Empty;
            }

            Dictionary<string, int> orderedDic = nameAndSum
                .OrderByDescending(x => x.Value)                
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 0;

            foreach (KeyValuePair<string, int> pair in orderedDic)
            {

                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == pair.Key)
                    {
                        count++;

                        if (count == 1)
                        {
                            Console.WriteLine($"{count}st place: {pair.Key}");
                        }
                        else if (count == 2)
                        {
                            Console.WriteLine($"{count}nd place: {pair.Key}");
                        }
                        else
                        {
                            Console.WriteLine($"{count}rd place: {pair.Key}");
                        }                     
                    }
                }   

                if (count == 3)
                {
                    break;
                }
            }
        }
    }
}
