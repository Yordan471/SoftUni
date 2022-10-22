using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
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

                string firstName = commandToInformationArray[0];
                string lastName = commandToInformationArray[1];
                int age = int.Parse(commandToInformationArray[2]);
                string homeTown = commandToInformationArray[3];

                if (StudentExists(students, firstName, lastName))
                {
                    Students student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                }
                else
                {
                    Students student = new Students()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    };

                    students.Add(student);
                }

                command = Console.ReadLine();
            }

            string homeTownCity = Console.ReadLine();

            foreach (Students student in students)
            {
                if (student.HomeTown == homeTownCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is" +
                        $" {student.Age} years old.");
                }
            }         
        }

        static bool StudentExists(List<Students> students, string firstName, string lastName)
        {
            foreach (Students student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
      
            return false;
        }

        static Students GetStudent(List<Students> students, string firstName, string lastName)
        {
            Students existingStudent = null;

            foreach (Students student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }
    }

    class Students
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }    

        public int Age { get; set; }    

        public string HomeTown { get; set; }

    }
}
