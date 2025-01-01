namespace WebApplication1.Models
{

    public class Student
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Roll { get; set; }
    }

    public class Something
    {
        private List<Student> students = new List<Student>();

        public List<Student> GetDependent()
        {
            students.Add(new Student
            {
                Name = "Satish",
                Roll = 1,
                Description = "This is Satish and its description"
            });
            students.Add(new Student
            {
                Name = "Ram",
                Roll = 2,
                Description = "This is Ram and its description"
            });
            return students;
        }

        public int GetByRoll(int roll)
        {
            foreach (var item in students)
            {
                if (item.Roll == roll)
                {
                    return item.Roll;
                }
            }
            return -1;
        }
    }

}
