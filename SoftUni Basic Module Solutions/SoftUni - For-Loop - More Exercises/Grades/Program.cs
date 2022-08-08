using System;

namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            int studentCounter5 = 0;
            int studentCounter4 = 0;
            int studentCounter3 = 0;
            int studentCounter2 = 0;
            decimal sumGrades = 0M;
            decimal averageGrades = 0M;

            for (int i = 1; i <= numberOfStudents; i++)
            {
                decimal grade = decimal.Parse(Console.ReadLine());
                sumGrades += grade;

                if (grade >= 5)
                {
                    studentCounter5++;
                }
                else if (grade >= 4.00M && grade <= 4.99M)
                {
                    studentCounter4++;
                }
                else if (grade >= 3M && grade <= 3.99M)
                {
                    studentCounter3++;
                }
                else if (grade < 3M)
                {
                    studentCounter2++;
                }
            }

            decimal topStudents = (studentCounter5 * 100.00M / numberOfStudents);
            Console.WriteLine($"Top students: {topStudents:f2}%");

            decimal students4 = (studentCounter4 * 100.00M / numberOfStudents);
            Console.WriteLine($"Between 4.00 and 4.99: {students4:f2}%");

            decimal students3 = (studentCounter3 * 100.00M / numberOfStudents);
            Console.WriteLine($"Between 3.00 and 3.99: {students3:f2}%");

            decimal students2 = (studentCounter2 * 100.00M / numberOfStudents);
            Console.WriteLine($"Fail: {students2:f2}%");

            averageGrades = sumGrades / numberOfStudents;
            Console.WriteLine($"Average: {averageGrades:f2}");
        }
    }
}
