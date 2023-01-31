namespace StudentAcademy
{
    public class Program
    {
        public static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine();
                decimal grade = decimal.Parse(Console.ReadLine());

                if (!students.Any(s => s.Name.Equals(name)))
                {
                    Student student = new(name);
                    student.Grades.Add(grade);
                    students.Add(student);
                    continue;
                }

                students
                    .Find(s => s.Name == name)
                    .Grades.Add(grade);
            }

            students = students
                .Select(s => s)
                .Where(s => s.Grades.Average() >= 4.50M)
                .ToList();

            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    public class Student
    {
        public Student()
        {
            this.Name = string.Empty;
            this.Grades = new();
        }

        public Student(string name) : this()
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public List<decimal> Grades { get; set; }

        public override string ToString()
        {
            return $"{this.Name} -> {this.Grades.Average():f2}";
        }
    }
}