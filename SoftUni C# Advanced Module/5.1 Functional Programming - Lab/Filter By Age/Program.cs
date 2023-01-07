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
