namespace MinimalApiProj
{
    public class Student
    {
        private readonly int _id;
        public string? Name { get; set; }
        public string? Course { get; set; }
        public int Age { get; set; }

        public int Id { get { return _id; } }
        public Student(int id)
        {
            _id = id;
        }
    }

    internal static class StudentOps
    {
        public static List<Student> students = new List<Student>();

        internal static Student GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return student;
        }

        internal static void Init()
        {
            students.Add(new Student(1)
            {
                Age = 18,
                Course = "Math",
                Name = "Ali"
            });
            students.Add(new Student(2)
            {
                Age = 20,
                Course = "Pilates",
                Name = "Sue"
            });
        }
        public static void AddStudent(Student student)
        {
            if (students.Count == 0)
            {
                students.Add(student);
            }
            var lastid = students.Max(x => x.Id);
            students.Add(new Student(lastid + 1)
            {
                Age = student.Age,
                Name = student.Name,
                Course = student.Course
            });
        }
    }


}
