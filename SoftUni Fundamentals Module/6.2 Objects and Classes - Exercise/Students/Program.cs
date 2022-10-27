using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfAllStudents = int.Parse(Console.ReadLine());

            List<Students> students = new List<Students>();

            for (int i = 0; i < countOfAllStudents; i++)
            {
                string[] information = Console.ReadLine().Split(' ');

                Students  student = new Students(information[0], information[1],
                  (information[2]));

                students.Add(student);
            }

            List<Students> orderByGrade = students.OrderByDescending(student => student.Grade).ToList();

            foreach (Students student in orderByGrade)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Students
    {
        public Students(string firstName, string lastName, string grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Grade { get; set; }

        public override string ToString() => $"{FirstName} {LastName}: {Grade}";

        public List<Students> students { get; set; }
    }
}
