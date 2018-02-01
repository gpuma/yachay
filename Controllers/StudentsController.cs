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
    }
}
