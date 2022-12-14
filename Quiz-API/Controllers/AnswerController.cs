using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Quiz_API.Controllers;

    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AnswerController : Controller
    {
        private AnswerService _answerService;
        
        public AnswerController(AnswerService answerService)
        {
        _answerService = answerService;
        }
        
        //TODO Behöver vi hämta alla svar? Känns mer logiskt att hämta ALLA frågor
        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Answer>))]
        public IActionResult Get()
        {
            return Ok(_answerService.GetAllAnswers());
        }

     
        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Answer))]
        public IActionResult Get(Guid id)
        {
           return Ok(_answerService.GetAnswers(id));
        }

        // ANVÄNDA ASYNC OCH AWAIT?
        /*
        public async Task<ActionResult<Answer>> GetAnswer(string id)
        {
            var answers = await _answerService.GetAnswers(id);
            if (answers == null)
            {
                return NotFound();
            }

            return Ok(answers);
        }
        */

        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Answer>))]
        public IActionResult Post([FromBody] Answer answer)
        {
            return Ok(_answerService.PostAnswer(answer));
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
            
            var isAnswerUpdated = _answerService.PutAnswer(answer);
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
            var isAnswerDeleted = _answerService.DeleteAnswer(id);
            if (isAnswerDeleted)
            {
                return Ok();
            }

            return NotFound();
        }
    }
