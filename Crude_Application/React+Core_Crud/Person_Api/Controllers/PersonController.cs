using Contract.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Person_Api.Controllers {
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase {
        private readonly IServiceManager _service;

        public PersonController(IServiceManager service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var persons = _service.PersonService.GetAllPersons(trackChanges: false);
            return Ok(persons);
        }

        [HttpGet("{id:long}")]
        public IActionResult Get(long id) {
            var person = _service.PersonService.GetPersonById(id, trackChanges: false);
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DTOPerson dtoPerson) {
            if (dtoPerson == null) {
                return BadRequest();
            }

            DTOPerson person = _service.PersonService.CreatePerson(dtoPerson);
            return Ok(person);
        }

        [HttpPut("{id:long}")]
        public IActionResult Update(long id, [FromBody]DTOPerson person) {
            if (id == 0 || person is null) {
                return BadRequest();
            }

            var isPersonUpdate = _service.PersonService.UpdatePerson(id, person);

            return Ok(new {
                PersonUpdate = isPersonUpdate
            });
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id) {
            if (id == 0) {
                return BadRequest();
            }

            var deletePersonDate = _service.PersonService.DeletePerson(id);

            return Ok(new {
                IsDelete = deletePersonDate.Item1,
                PersonId = deletePersonDate.Item2
            });
        }
    }
}
