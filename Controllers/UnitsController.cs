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
            //TODO: check this
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
    }
}
