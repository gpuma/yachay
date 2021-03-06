using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using yachay.Models;

namespace yachay.Controllers
{
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {
        private readonly YachayContext _context;
        
        public UnitsController(YachayContext context)
        {
            _context = context;    
        }

        //GET: All units
        [HttpGet]
        public IEnumerable<Unit> Index()
        {
            return  _context.Units.ToList();
        }

        [HttpGet("{id}")]
        public Unit GetUnit(int id)
        {
            var unit = _context.Units.Find(id);
            if (unit != null)
            {
                // explicit loading (kind of)
                // source: https://stackoverflow.com/a/41535211/344162
                _context.Entry(unit).Collection(u => u.Enrollments)
                    .Query().Include(e => e.Student).Load();
            }
            return unit;
        }

        [HttpPost("[action]")]
        public int Update([FromBody]Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return -1;
            }

            _context.Update(unit);
            _context.SaveChanges();
            return 0;
        }
        
        [HttpPost("[action]")]
        public Unit Add([FromBody]Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            _context.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        [HttpGet("{unitId}/[action]")]
        //displays a list of available students
        //to be enrolled in the specifid unit
        public IEnumerable<Student> Enroll(int unitId)
        {
            var currentUnit = this.GetUnit(unitId);
            //we obtain the list of the ids of the students
            //currently enrolled in the unit to filter them out
            var enrolledStudents = 
                (from e in currentUnit.Enrollments
                select e.StudentId).AsEnumerable();
            
            //display only students not enrolled in this unit
            return _context.Students.Where(s => !enrolledStudents.Contains(s.StudentId) );
        }

        [HttpPost("{unitId}/[action]")]
        //enrolls the list of students to the specified unit
        public int ConfirmEnrollment(int unitId, [FromBody]IEnumerable<Student> students)
        {
            //we do not add the `Student` reference since that will
            //make EF think that we're creating new students
            var newEnrollments = (
                from s in students
                select new Enrollment() { UnitId = unitId, StudentId = s.StudentId}
            ).AsEnumerable().ToList();
            _context.Enrollments.AddRange(newEnrollments);
            _context.SaveChanges();
            return 0;
        }

        [HttpPost("{unitId}/[action]")]
        //we need `FromBody` since this is a complex type
        public int Remove(int unitId)
        {
            var unit = _context.Units.Find(unitId);
            _context.Remove(unit);
            _context.SaveChanges();
            return 0;
        }
    }
}
