using System;
using System.Collections.Generic;
using System.Linq;

namespace Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Students> students = new List<Students>();

            while (true)
            {
                if (command == "end")
                {
                    break;
                }

                string[] commandToInformationArray = command
                    .Split(' ')
                    .ToArray();

                Students student = new Students(commandToInformationArray[0],
                    commandToInformationArray[1], int.Parse(commandToInformationArray[2]),
                    commandToInformationArray[3]);

                if (students.Contains())

                students.Add(student);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            foreach (Students student in students)
            {
                if (student.HomeTown == command)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is" +
                        $" {student.age} years old.");
                }
            }
        }
    }

    class Students
    {
        public Students(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.age = age;
            this.HomeTown = homeTown;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int age { get; set; }

        public string HomeTown { get; set; }
    }
}
