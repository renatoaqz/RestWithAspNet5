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
    public class CalculatorController : ControllerBase
    {
       

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult Get(string firstnumber, string secondnumber)
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
