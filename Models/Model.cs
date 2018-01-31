using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace yachay.Models
{
    public class YachayContext : DbContext
    {
        public YachayContext(DbContextOptions<YachayContext> options)
            : base(options)
        { }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
    public class Unit
    {
        public int UnitId { get; set; }
        public int Name { get; set; }
        public string Semester { get; set; }
        public float Weight1 { get; set; }
        public float Weight2 { get; set; }
        public float Weight3 { get; set; }
    }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int UnitId { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
    }

    public class Student
    {
        public int StudentId  { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName  { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName  { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public float? Grade1 { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public float? Grade2 { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public float? Grade3 { get; set; }

        // // references to unit
        // //public int UnitId  { get; set; }
        // public Enrollment Enrollment  { get; set; }
        

        // // references to student
        // //public int StudentId { get; set; }
        // public Student Student { get; set; }
    }
}