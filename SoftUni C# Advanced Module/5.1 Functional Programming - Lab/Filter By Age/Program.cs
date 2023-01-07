using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Dictionary<string, int> nameAndAge = new Dictionary<string, int>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                if (!nameAndAge.ContainsKey(name))
                {
                    nameAndAge[name] = 0;
                }

                nameAndAge[name] = age;
            }

            string oldOrYoungCondition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string[] nameAgeCondition = Console.ReadLine()
                .Split()
                .ToArray();

            if (oldOrYoungCondition == "older")
            {
                nameAndAge = nameAndAge
                       .Where(p => p.Value >= ageCondition)
                       .ToDictionary(p => p.Key, c => c.Value);

                if (nameAgeCondition.Length > 1)
                {
                    foreach(KeyValuePair<string, int> person in nameAndAge)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
                else if (nameAgeCondition[0] == "name")
                {
                    foreach (string name in nameAndAge.Keys)
                    {
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    foreach (int age in nameAndAge.Values)
                    {
                        Console.WriteLine(age);
                    }
                }
            }
            else
            {
                nameAndAge = nameAndAge
                      .Where(p => p.Value < ageCondition)
                      .ToDictionary(p => p.Key, c => c.Value);

                if (nameAgeCondition.Length > 1)
                {
                    foreach (KeyValuePair<string, int> person in nameAndAge)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
                else if (nameAgeCondition[0] == "name")
                {
                    foreach (string name in nameAndAge.Keys)
                    {
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    foreach (int age in nameAndAge.Values)
                    {
                        Console.WriteLine(age);
                    }
                }
            }
        }
    }
}
