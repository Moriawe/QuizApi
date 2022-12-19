using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Persistance;
using Swashbuckle.AspNetCore.Annotations;
using Quiz_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuestionController : ControllerBase
    {
        private QuestionService _service; // Should recieve as argument in constructor.

        public QuestionController(QuestionService service)
        {
            _service = service;
        }


        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Get()
        {
            //Service:
            return Ok(_service.Get());
        }


        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Question))]
        public IActionResult Get(Guid id)
        {
            //Service:
            var question = _service.Get(id);
            if (question == null)
            {
                return NotFound("Id not found");
            }
            return Ok(question);
        }


        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Post([FromBody] Question question) // Probably skip [FromBody]
        {
            return Ok(_service.Post(question));
        }


        // PUT api/values/5
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Put([FromBody] Question question) // Probably skip [FromBody]
        {
            var questions = _service.Put(question); // This returns too late, I think

            if (questions == null)
            {
                return NotFound("Question not found");
            }
            return Ok(questions);
        }


        // DELETE api/values/5
        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public IActionResult Delete([FromBody] Question question) // Probably skip [FromBody]
        {
            var success = _service.Delete(question);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}

