using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Quiz_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AnswerController : ControllerBase
    {
        private AnswerService _service;

        public AnswerController(AnswerService service)
        {
            _service = service;
        }


        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Answer>))]
        public IActionResult Get()
        {
            return Ok(_service.GetAllAnswers());
        }


        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Answer))]
        public IActionResult Get(Guid id)
        {
            return Ok(_service.GetAnswerByID(id));
        }


        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Answer))]
        public IActionResult Post(Answer answer) // Probably skip [FromBody]
        {
            return Ok(_service.PostAnswer(answer));
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Answer>))]
        public IActionResult Put(Guid id, [FromBody] Answer answer)
        {
            if (id != answer.Id)
            {
                return BadRequest("Invalid id");
            }

            var isAnswerUpdated = _service.PutAnswer(answer);
            if (isAnswerUpdated)
            {
                return Ok();
            }
            return NotFound();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public IActionResult Delete(Guid id)
        {
            var isAnswerDeleted = _service.DeleteAnswer(id);
            if (isAnswerDeleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
