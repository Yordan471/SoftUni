using System;

namespace TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jurryMemNum = int.Parse(Console.ReadLine());
            double totalGradeForCourse = 0;
            int lecturesCounter = 0;

            while (true)
            {
                string command = Console.ReadLine();//многократно четене на стринг

                if (command == "Finish") // проверяваме дали strinovete съвпадат
                {
                    break; // спираме при прочитане на finish
                }

                string lectureTitle = command;// по-подходящо име
                lecturesCounter++;

                double totalGradeForLecture = 0; //цяла стойност за презентацийте

                for (int i = 1; i <= jurryMemNum; i++)
                {
                    double gradeForLecture = double.Parse(Console.ReadLine()); //четем оценките от лекторите

                    totalGradeForLecture += gradeForLecture; // прибавяме всички оценки от лектоите към цял сбор
                }

                double averageForLecture = totalGradeForLecture / jurryMemNum; // средна оценка за дадена лекция
                Console.WriteLine($"{lectureTitle} - {averageForLecture:f2}.");

                totalGradeForCourse += averageForLecture;
            }

            double averageForCourse = totalGradeForCourse / lecturesCounter; 
            Console.WriteLine($"Student's final assessment is {averageForCourse:f2}.");
        }
    }
}
