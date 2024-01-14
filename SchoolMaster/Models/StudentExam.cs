using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMaster.Models
{
    public class StudentExam
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Mark { get; set; }
    }
}
