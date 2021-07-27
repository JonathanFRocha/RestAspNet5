using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestCalculator.Model;
using RestPerson.Business;

namespace RestCalculator.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
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
        public IActionResult Get(long id)
        {
            Person person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Person person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
