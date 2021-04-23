using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonrController : ControllerBase
    {
       
        private readonly ILogger<PersonrController> _logger;

        public PersonrController(ILogger<PersonrController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult Sum(string firstnumber, string secondnumber)
        {
            if(IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = Convert.ToDecimal(firstnumber) + Convert.ToDecimal(secondnumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strnumber)
        {
            double number;

            return double.TryParse(strnumber, out number);
        }
    }
}
