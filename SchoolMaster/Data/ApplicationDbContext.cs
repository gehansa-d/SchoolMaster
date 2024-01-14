using System.Drawing;
using System.Reflection.Emit;
using Azure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SchoolMaster.Models;

namespace SchoolMaster.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>().HasMany(e => e.Exams)
                .WithMany(d => d.Students)
                .UsingEntity<StudentExam>(
                    j => j
                        .HasOne(fff => fff.Exam)
                        .WithMany(ff => ff.StudentExams)
                        .OnDelete(DeleteBehavior.Restrict),
                     j => j.HasOne(fff => fff.Student)
                        .WithMany(f => f.StudentExams)
                        .OnDelete(DeleteBehavior.Restrict),
                    j =>
                    {
                        j.HasKey(t => t.Id);
                    });
        }
    }
}
