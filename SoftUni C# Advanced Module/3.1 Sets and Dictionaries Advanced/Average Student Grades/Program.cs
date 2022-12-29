using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentAndGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(' ');

                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!(studentAndGrades.ContainsKey(studentName)))
                {
                    studentAndGrades[studentName] = new List<decimal>();
                }

                studentAndGrades[studentName].Add(grade);
            }

            foreach (KeyValuePair<string, List<decimal>> student in studentAndGrades)
            {
                Console.Write($"{student.Key} -> ");

                foreach (decimal grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
