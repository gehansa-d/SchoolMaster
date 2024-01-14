namespace SchoolMaster.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<StudentExam> StudentExams { get; set; }
    }
}
