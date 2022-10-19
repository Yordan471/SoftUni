using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata;

namespace SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
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

                    if (initialLessons.Contains(lessonTitle + "-Exercise"))
                    {
                        initialLessons.Remove(lessonTitle + "-Exercise");
                    }
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
                    string exercise = lessonTitle + "-Exercise";

                    if (initialLessons.Contains(lessonTitle) &&
                        initialLessons.Contains(exercise) == false)
                    {
                        AddExerciseLesson(initialLessons, lessonTitle);
                    }
                    else if (initialLessons.Contains(exercise) == false)
                    {
                        AddLessonAndExercise(initialLessons, lessonTitle);
                    }
                }

                command = Console.ReadLine();
            }

            int counter = 0;

            foreach (string lesson in initialLessons)
            {
                counter++;
                Console.WriteLine($"{counter}.{lesson}");
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
            initialLessons.Insert(firstIndex, lessonTitleSecond);

            initialLessons.RemoveAt(secondIndex);
            initialLessons.Insert(secondIndex, lessonTitleFirst);

            if (initialLessons.Contains(lessonTitleFirst + "-Exercise"))
            {
                initialLessons.RemoveAt(firstIndex + 1);

                if (initialLessons.Contains(lessonTitleSecond + "-Exercise"))
                {
                    initialLessons.Insert(firstIndex + 1, lessonTitleSecond + "-Exercise");
                    initialLessons.RemoveAt(secondIndex + 1);
                }

                initialLessons.Insert(secondIndex + 1, lessonTitleFirst + "-Exercise");
            }
            else if (initialLessons.Contains(lessonTitleSecond + "-Exercise"))
            {
                initialLessons.RemoveAt(secondIndex + 1);

                if (initialLessons.Contains(lessonTitleFirst + "-Exercise"))
                {
                    initialLessons.Insert(secondIndex + 1, lessonTitleFirst + "-Exercise");
                    initialLessons.RemoveAt(firstIndex + 1);
                }

                initialLessons.Insert(firstIndex + 1, lessonTitleSecond + "-Exercise");
            }
           
            return initialLessons;
        }

        static List<string> AddExerciseLesson(List<string> initialLessons, string lessonTitle)
        {
            int indexOfLesson = initialLessons.IndexOf(lessonTitle);
            string addingExercise = lessonTitle + "-Exercise";
            initialLessons.Insert(indexOfLesson + 1, addingExercise);

            return initialLessons;

        }

        static List<string> AddLessonAndExercise(List<string> initialLessons, string lessonTitle)
        {
            initialLessons.Add(lessonTitle);
            string addingExercise = lessonTitle + "-Exercise";
            initialLessons.Add(addingExercise);

            return initialLessons;
        }
    }
}
