using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Exam_Result
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> studentAndSubPoints = new
                Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> submissionsCount = new Dictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] studentInfo = command
                    .Split('-');

                string studentName = studentInfo[0];
                string language = studentInfo[1];              

                if (language != "banned")
                {
                    int points = int.Parse(studentInfo[2]);

                    if (!studentAndSubPoints.ContainsKey(studentName))
                    {
                        studentAndSubPoints.Add(studentName, new Dictionary<string, int>());
                        studentAndSubPoints[studentName].Add(language, 0);
                    }
                    else if (!studentAndSubPoints[studentName].ContainsKey(language))
                    {
                        studentAndSubPoints[studentName].Add(language, 0);
                    }

                    if (!submissionsCount.ContainsKey(language))
                    {
                        submissionsCount.Add(language, 0);
                    }

                    submissionsCount[language]++;

                    if (studentAndSubPoints[studentName][language] < points)
                    {
                        studentAndSubPoints[studentName][language] = points;
                    }
                }
                else if (language == "banned")
                {
                    if (studentAndSubPoints.ContainsKey(studentName))
                    {
                        studentAndSubPoints.Remove(studentName);
                    }
                }
            }

            Console.WriteLine($"Result:");

            foreach (var student in studentAndSubPoints
                .OrderByDescending(x => x.Value.Values.Max())
                .ThenBy(x => x.Key))
            {               
                foreach (var studentInfo in student.Value)
                {
                    Console.WriteLine($"{student.Key} | {studentInfo.Value}");
                }
            }

            foreach (var language in submissionsCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
