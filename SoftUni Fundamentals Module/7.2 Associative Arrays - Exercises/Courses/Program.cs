using System;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] courseStudentsArray = Console.ReadLine()
                .Split(" : ");

            Dictionary<string, List<string>> coursesAndStudents = new Dictionary<string, List<string>>();

            while (courseStudentsArray[0] != "end")
            {
                string courseName = courseStudentsArray[0];
                string studentName = courseStudentsArray[1];

                if (!coursesAndStudents.ContainsKey(courseName))
                {
                    coursesAndStudents.Add(courseName, new List<string>() { studentName });
                }
                else
                {
                    coursesAndStudents[courseName].Add(studentName);
                }

                courseStudentsArray = Console.ReadLine()
                .Split(" : ");
            }
               
            foreach (KeyValuePair<string, List<string>> student in coursesAndStudents)
            {
                Console.WriteLine($"{student.Key}: {student.Value.Count}");

                for (int i = 0; i < student.Value.Count; i++)
                {
                    Console.WriteLine($"-- {student.Value[i]}");
                }
            }
        }
    }
}
