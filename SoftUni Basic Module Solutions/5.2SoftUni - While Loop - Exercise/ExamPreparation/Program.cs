using System;

namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int failedThreshold = int.Parse(Console.ReadLine());

            int failedGrades = 0;
            int solvedProblems = 0;
            double sumGrades = 0;
            string lastProblem = "";
            bool isFailed = true;

            while (failedGrades < failedThreshold)
            {
                string nameProblem = Console.ReadLine();
                if (nameProblem == "Enough")
                {
                    isFailed = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failedGrades++;
                }
                sumGrades += grade;
                solvedProblems++;
                lastProblem = nameProblem;
            }
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {failedThreshold} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {sumGrades / solvedProblems:F2}");
                Console.WriteLine($"Number of problems: {solvedProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
