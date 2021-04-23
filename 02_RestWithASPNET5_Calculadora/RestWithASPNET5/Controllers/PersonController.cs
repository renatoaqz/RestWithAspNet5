using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Model;
using RestWithASPNET5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long Id)
        {
            var person = _personService.FindByID(Id);

            if (person != null)
                return Ok(_personService.FindByID(Id));
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personService.Create(person));
            else
                return BadRequest();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personService.Update(person));
            else
                return BadRequest(); 
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(long Id)
        {
            var person = _personService.FindByID(Id);
            if (person != null)
            {
                _personService.Delete(Id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool IsNumeric(string strnumber)
        {
            double number;

            return double.TryParse(strnumber, out number);
        }
    }
}
