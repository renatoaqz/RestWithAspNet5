using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Business;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long Id)
        {
            var person = _personBusiness.FindByID(Id);

            if (person != null)
                return Ok(_personBusiness.FindByID(Id));
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personBusiness.Create(person));
            else
                return BadRequest();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personBusiness.Update(person));
            else
                return BadRequest(); 
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(long Id)
        {
            var person = _personBusiness.FindByID(Id);
            if (person != null)
            {
                _personBusiness.Delete(Id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
