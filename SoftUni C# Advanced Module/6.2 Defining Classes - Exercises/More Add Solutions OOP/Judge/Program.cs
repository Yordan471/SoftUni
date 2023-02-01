using System.Runtime.CompilerServices;
using System.Text;

namespace Judge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;

            List<Student> students = new List<Student>();
            List<Contest> contests = new List<Contest>();           
            
            while ((command = Console.ReadLine()) != "no more time")
           {
                string[] studentInfo = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentInfo[0];
                string contestName = studentInfo[1];
                int points = int.Parse(studentInfo[2]);

                Student student = new();
                Contest contest = new();

                if (contests
                    .Any(s => s.ContestName.Equals(contestName) && s.Students
                    .Any(c => c.StudentName == studentName && c.Points < points)))
                {
                    foreach (var cont in contests)
                    {
                        if (cont.ContestName.Equals(contestName))
                        {
                            Student removeStudent = cont.Students
                                .Where(c => c.StudentName.Equals(studentName))
                                .FirstOrDefault();
                            removeStudent.Points = points;
                            break;
                        }                      
                    }
                }
                else if (contests
                    .Any(s => s.ContestName.Equals(contestName) && !s.Students
                    .Any(c => c.StudentName == studentName)))
                {
                    contests
                        .Find(s => s.ContestName.Equals(contestName)).Students
                        .Add(new Student(studentName, points));
                }
                
                if (!contests.Any(c => c.ContestName.Equals(contestName)))
                {
                    contest.ContestName = contestName;
                    contest.Students.Add(new Student(studentName, points));
                    contests.Add(contest);
                }
            }

            foreach (var cont in contests)
            {
                Console.WriteLine($"{cont.ContestName}: {cont.Students.Count} participants");
                int count = 0;

                foreach (var student in cont.Students.OrderByDescending(s => s.Points).ThenBy(s => s.StudentName))
                {
                    count++;
                    Console.WriteLine($"{count}. {student.StudentName} <::> {student.Points}");
                }
            }

            Console.WriteLine("Individual standings:");
            Dictionary<string, List<int>> studentPoints = new();

            foreach (var cont in contests)
            {
                foreach (var student in cont.Students)
                {
                    if (!studentPoints.ContainsKey(student.StudentName))
                    {
                        studentPoints.Add(student.StudentName, new List<int>());
                    }

                    studentPoints[student.StudentName].Add(student.Points);
                }
            }

            int counter = 0;
            foreach (var student in studentPoints.OrderByDescending(s => s.Value.Sum()).ThenBy(s => s.Key))
            {
                counter++;
                Console.WriteLine($"{counter}. {student.Key} -> {student.Value.Sum()}");
            }
        }
    }

    public class Student
    {
        public Student()
        {
            StudentName = "";
            Points = 0;
        }

        public Student(string studentName, int points) : this()
        {
            StudentName = studentName;
            Points = points;
        }

        public string StudentName { get; set; }

        public int Points { get; set; }
    }

    public class Contest
    {
        public Contest()
        {
            ContestName = "";
            Students = new();
        }

        public Contest(string contestName) : this()
        {
            ContestName = contestName;
        }

        public string ContestName { get; set; }

        public List<Student> Students { get; set; }
    }
}