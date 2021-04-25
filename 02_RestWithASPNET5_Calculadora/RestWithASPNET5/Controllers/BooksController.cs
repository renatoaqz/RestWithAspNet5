using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET5.Business;
using RestWithASPNET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private IBooksBusinnes _booksBusinnes;

        public BooksController(ILogger<BooksController> logger, IBooksBusinnes booksBusiness)
        {
            _logger = logger;
            _booksBusinnes = booksBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusinnes.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var book = _booksBusinnes.FindByID(Id);

            if (book != null)
                return Ok(_booksBusinnes.FindByID(Id));
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Books book)
        {
            if (book != null)
                return Ok(_booksBusinnes.Create(book));
            else
                return BadRequest();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Books book)
        {
            if (book != null)
                return Ok(_booksBusinnes.Update(book));
            else
                return BadRequest();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var book = _booksBusinnes.FindByID(Id);
            if (book != null)
            {
                _booksBusinnes.Delete(Id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
