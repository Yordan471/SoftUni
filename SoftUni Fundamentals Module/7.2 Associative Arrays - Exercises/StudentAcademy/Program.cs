using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputData = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfInputData; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(studentName))
                {
                    studentsGrades.Add(studentName, new List<double>() { studentGrade });
                }
                else
                {
                    studentsGrades[studentName].Add(studentGrade);
                }
            }

            Dictionary<string, double> avrgValues = studentsGrades
                .ToDictionary(
                student => student.Key,
                student => student.Value.Average());

            foreach (KeyValuePair<string, double> student in avrgValues)
            {
                if (student.Value >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value:f2}");
                }
            }          
        }
    }
}
