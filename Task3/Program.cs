using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        public delegate string GroupBy(Student student);

        public static void Main(string[] args)
        {
            List<Student> list = new List<Student>();

            list.Add(new Student()
            {
                Age = "17",
                Gender = "Female",
                Name = "Test",
                Id = 1
            });

            list.Add(new Student()
            {
                Age = "18",
                Gender = "Female",
                Name = "Test2",
                Id = 2
            });

            list.Add(new Student()
            {
                Age = "18",
                Gender = "Female",
                Name = "Test3",
                Id = 3
            });

            var group = Group(list, (s) => s.Age);
           
        }

        public static Dictionary<string, List<Student>> Group(List<Student> students, GroupBy groupBy)
        {
            Dictionary<string, List<Student>> result = new Dictionary<string, List<Student>>();

            foreach (var student in students)
            {
                string key = groupBy?.Invoke(student);

                if (!result.ContainsKey(key))
                {
                    result[key] = new List<Student>();
                }

                result[key].Add(student);
            }

            return result;
        }

        public static string GropByGender(Student student)
        {
            return student.Gender;
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
    }
}