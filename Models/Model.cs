using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//for [NotMapped]
using System.ComponentModel.DataAnnotations.Schema;

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
    }

    public class Unit
    {
        public int UnitId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Semester { get; set; }
        [Required]
        public float Weight1 { get; set; }
        [Required]
        public float Weight2 { get; set; }
        [Required]
        public float Weight3 { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        
        [DisplayFormat(NullDisplayText = "No grade")]
        public float? Grade1 { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public float? Grade2 { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public float? Grade3 { get; set; }
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

        public List<Enrollment> Enrollments { get; set; }

        //used for client purposes
        [NotMapped]
        public bool Enroll {get; set; }
    }
}