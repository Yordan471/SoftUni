using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Filter_By_Age
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                people.Add(person);                  
            }

            string conditionYoungOrOld = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());

            Func<Person, bool> filterAge = CreateFilter(conditionYoungOrOld, conditionAge);

            string conditionNameAge = Console.ReadLine();

            Action<Person> print = CreatePriner(conditionNameAge);
        }

        static void PrintResult(List<Person> people, Func<Person, bool> filterAge, Action<Person> print)
        {
            foreach (Person person in people)
            {
                print(person);
            }
        }

        static Action<Person> CreatePriner(string conditionNameAge)
        {
            switch (conditionNameAge)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Name}");
                case "age":
                    return age => Console.WriteLine($"{age.Age}");
                case "name age":
                    return nameAge => Console.WriteLine($"{nameAge.Name} - {nameAge.Age}");
                default:
                    throw new ArgumentException(conditionNameAge);
            }
        }

        static Func<Person, bool> CreateFilter(string conditionYoungOrOld, int conditionAge)
        {
            switch (conditionYoungOrOld)
            {
                case "older":
                    return x => x.Age >= conditionAge;
                case "younger":
                    return x => x.Age < conditionAge;
                default:
                    throw new ArgumentException(conditionYoungOrOld);
            }
        }

    }

    class Person
    {
        public Person (string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
