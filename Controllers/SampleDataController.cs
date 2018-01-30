using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace yachay.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }


        //TODO: put all student stuff in other controller
        [HttpGet("[action]")]
        public IEnumerable<Student> Students()
        {
            return new Student[]
            {
                new Student { CUI="1234", FirstName = "Gustavo", LastName = "Puma" },
                new Student { CUI="5678", FirstName = "Bruno", LastName = "García" },
                new Student { CUI="9101", FirstName = "Arturo", LastName = "Salazar" }
            };
        }

        [HttpPost("[action]")]
        public Student PruebaPost([FromBody]Student stu)
        {
            return stu;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
        public class Student
        {
            public string FirstName {get; set;}
            public string LastName {get; set;}
            public string CUI {get; set;}
        }
    }
}
