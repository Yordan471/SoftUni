﻿using System.Threading.Channels;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new();

            for (int i = 0; i < lines; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new(personInfo[0], personInfo[1], int.Parse(personInfo[2]));
                persons.Add(person);
            }

            persons.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
