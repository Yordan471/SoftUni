using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLessons = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = string.Empty;

            while (true)
            {
                if (command == "course start")
                {
                    break;
                }

                List<string> commandToList = command
                    .Split(':')
                    .ToList();

                string operation = commandToList[0];

                if (operation == "Add")
                {
                    string lessonTitle = commandToList[1];

                    AddLessons(initialLessons, lessonTitle);
                }
                else if (operation == "Insert")
                {
                    string lessonTitle = commandToList[1];
                    int index = int.Parse(commandToList[2]);

                    if (index >= 0 && index < initialLessons.Count)
                    {
                        InsertLessons(initialLessons, lessonTitle, index);
                    }
                }
                else if (operation == "Remove")
                {
                    string lessonTitle = commandToList[1];

                    RemoveLessons(initialLessons, lessonTitle);
                }
                else if (operation == "Swap")
                {
                    string lessonTitleFirst = commandToList[1];
                    string lessonTitleSecond = commandToList[2];

                    if (initialLessons.Contains(lessonTitleFirst) &&
                        initialLessons.Contains(lessonTitleSecond))
                    {
                        SwapLessons(initialLessons, lessonTitleFirst, lessonTitleSecond);
                    }
                }
                else if (operation == "Exercise")
                {
                    string lessonTitle = commandToList[1];

                    if (initialLessons.Contains(lessonTitle))
                    {
                        AddExerciseLesson(initialLessons, lessonTitle);
                    }
                    else
                    {

                    }
                }

                command = Console.ReadLine();
            }


        }

        static List<string> AddLessons(List<string> initialLessons, string lessonTitle)
        {
            if (initialLessons.Contains(lessonTitle) == false)
            {
                initialLessons.Add(lessonTitle);
            }

            return initialLessons;
        }

        static List<string> InsertLessons(List<string> initialLessons, string lessonTitle, int index)
        {
            if (initialLessons.Contains(lessonTitle) == false)
            {
                initialLessons.Insert(index, lessonTitle);
            }

            return initialLessons;
        }

        static List<string> RemoveLessons(List<string> initialLessons, string lessonTitle)
        {
            if (initialLessons.Contains(lessonTitle))
            {
                initialLessons.Remove(lessonTitle);
            }

            return initialLessons;
        }

        static List<string> SwapLessons(List<string> initialLessons, string lessonTitleFirst, string lessonTitleSecond)
        {
            int firstIndex = initialLessons.IndexOf(lessonTitleFirst);
            int secondIndex = initialLessons.IndexOf(lessonTitleSecond);

            initialLessons.RemoveAt(firstIndex);
            initialLessons.RemoveAt(secondIndex);

            initialLessons.Insert(firstIndex, lessonTitleSecond);
            initialLessons.Insert(secondIndex, lessonTitleFirst);

            return initialLessons;
        }

        static List<string> AddExerciseLesson(List<string> initialLessons, string lessonTitle)
        {
            int indexOfLesson = initialLessons.IndexOf(lessonTitle);
            string AddingExercise = lessonTitle + "-Exercise";
            initialLessons.Insert(indexOfLesson + 1, AddingExercise);

            return initialLessons;

        }

        static List<string> AddLessonAndExercise(List<string> initialLessons, string lessonTitle)
        {

        }
    }
}
