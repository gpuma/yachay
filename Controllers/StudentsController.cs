using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using yachay.Models;

namespace yachay.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly YachayContext _context;
        
        public StudentsController(YachayContext context)
        {
            _context = context;    
        }

        //GET: All students
        [HttpGet]
        public IEnumerable<Student> Index()
        {
            return  _context.Students.ToList();
        }

        [HttpGet("{studentId}")]
        public IEnumerable<Enrollment> GetEnrollments(int studentId)
        {
            //filter first
            var enrollments = _context.Enrollments.Where(
                                e => e.StudentId == studentId);

            if (enrollments.Count() != 0)
            {
                //then load related entities
                foreach(var enroll in enrollments)
                {
                    _context.Entry(enroll).Reference(e => e.Unit).Load();
                }
            }
            return enrollments;
        }

        [HttpPost("[action]")]
        //we need `FromBody` since this is a complex type
        public Student Add([FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            _context.Add(student);
            _context.SaveChanges();
            return student;
        }

        [HttpPost("{studentId}/[action]")]
        //we need `FromBody` since this is a complex type
        public int Remove(int studentId)
        {
            var student = _context.Students.Find(studentId);
            _context.Remove(student);
            _context.SaveChanges();
            return 0;
        }
    }
}
