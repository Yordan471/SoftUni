using System;

namespace _5._Programming_Fundamentals___Practice_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonusPounts = -10000000;
            double bonusPoints = 0;
            double saveAttendances = 0;

            if (numberOfStudents == 0)
            {
                maxBonusPounts = 0;
            }

            for (int i = 1; i < numberOfStudents; i++)
            {
                double attendances = int.Parse(Console.ReadLine());

                bonusPoints = (attendances / (numberOfLectures) * (5 + additionalBonus) * 1.0);

                if (bonusPoints >= maxBonusPounts)
                {
                    maxBonusPounts = bonusPoints;
                    saveAttendances = attendances;
                }
            }

            maxBonusPounts = Math.Ceiling(maxBonusPounts);
            Console.WriteLine($"Max Bonus: {maxBonusPounts}.");
            Console.WriteLine($"The student has attended {saveAttendances} lectures.");
        }
    }
}
