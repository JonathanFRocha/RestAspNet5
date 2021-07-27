using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestPerson.Business;
using RestPerson.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPerson.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Book book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            Book book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
