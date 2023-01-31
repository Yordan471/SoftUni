using System.Text;

namespace Courses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            List<Course> courses = new List<Course>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] courseInfo = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = courseInfo[0];
                string studentName = courseInfo[1];

                if (!courses.Any(c => c.CourseName == courseName))
                {
                    Course currCourse = new(courseName);
                    currCourse.AddStudent(studentName);
                    courses.Add(currCourse);
                    continue;
                }

                courses
                    .Find(c => c.CourseName
                    .Equals(courseName))
                    .AddStudent(studentName);
            }

            foreach (Course course in courses)
            {
                Console.WriteLine(course.ToString()); 
            }
        }
    }


    public class Course
    {
        public Course()
        {
            this.CourseName = string.Empty;
            this.Students = new();
        }


        public Course(string courseName) : this()
        {
            this.CourseName = courseName;

        }

        public string CourseName { get; set; }

        public List<Course> Courses = new();

        public List<string> Students { get; set; }

        public void AddStudent(string studentName)
        {
            this.Students.Add(studentName);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{CourseName}: {Students.Count}");

            foreach (var student in this.Students)
            {
                sb.AppendLine($"-- {student}");
            }

            return sb.ToString().Trim();
        }
    }
}