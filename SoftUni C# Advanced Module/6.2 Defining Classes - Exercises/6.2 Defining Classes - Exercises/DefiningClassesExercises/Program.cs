using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            Family family = new();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> filteredAbove30 = family.GetAgeAbove30();

            PrintPeople(filteredAbove30);
        }

        public static void PrintPeople(List<Person> filteredAbove30)
        {
            foreach (Person person in filteredAbove30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}