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
            var units = _context.Units.Include(u=> u.Enrollments)
                        .ThenInclude(e => e.Student);
            // var unit = _context.Units.Find(id);
            // //explicit loading
            // _context.Entry(unit).Collection(u => u.Enrollments);
            return units.First();
        }
    }
}
