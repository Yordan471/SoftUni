using System;

namespace Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int currentClass = 1;
            double totalGrades = 0;
            int repeatCount = 0;

            while (currentClass <= 12)
            {
                double currClassGrade = double.Parse(Console.ReadLine());
                totalGrades += currClassGrade;
                // if the grade is under 4 repeat the same class
                if (currClassGrade < 4)
                {
                    repeatCount++;

                    if (repeatCount > 1)
                    {
                        break;
                    }
                    continue; // repeat the above without exec the code under.
                }
                currentClass++;
            }

            if (repeatCount > 1)
            {
                Console.WriteLine($"{name} has been excluded at {currentClass} grade");
            }
            else
            {
                double averageGrade = totalGrades / (currentClass - 1 + repeatCount);
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
