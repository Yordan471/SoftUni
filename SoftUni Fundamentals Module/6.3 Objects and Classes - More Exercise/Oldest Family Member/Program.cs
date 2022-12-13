using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldest_Family_Member
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(' ');

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person= new Person(name, age);

                people.Add(person);
            }

            Person oldestPerson = people
                .OrderByDescending(p => p.Age)
                .First();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
