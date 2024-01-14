using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMaster.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("nvarchar(12)")]
        public string Nic { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
    }
}
