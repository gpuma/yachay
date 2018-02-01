using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}
