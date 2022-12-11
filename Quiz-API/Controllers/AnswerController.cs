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
        // MOCK Storage:
        static List<Answer> Answers = new List<Answer>();
        
        public AnswerController()
        {
            _answerService = new AnswerService();
        }
        
        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Answer>))]
        public IActionResult Get()
        {
            return Ok(Answers);
        }

     
        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Answer))]
        public IActionResult Get(string id)
        {
            //var listOfAnswers = Answers.Where(answer => answer.QuestionId == id).ToList();
            //return Ok(listOfAnswers);

            return Ok(_answerService.GetAnswers(id));
        }
        

        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Answer>))]
        public IActionResult Post([FromBody] Answer answer)
        {
            //Answers.Add(answer);
            //return Ok(Answers);

            return Ok(_answerService.PostAnswer(answer));
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Answer>))]
        public IActionResult Put([FromBody] Answer answer)
        {
            // var foundAnswer = Answers.FirstOrDefault(x => x.Id == answer.Id);
            // if (foundAnswer == null)
            // {
            //     return NotFound();
            // }
            // else
            // {
            //     Answers.Remove(foundAnswer);
            //     Answers.Add(answer);
            //     return Ok(Answers);
            // }
            
            // TODO Ingen nullhantering!!
            Answer foundAnswer = _answerService.PutAnswer(answer);

            return Ok(foundAnswer);
            
        }

        // DELETE api/values/5
        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public IActionResult Delete([FromBody] Answer answer)
        {
            // var foundAnswer = Answers.FirstOrDefault(x => x.Id == answer.Id);
            // if (foundAnswer == null)
            // {
            //     return NotFound();
            // }
            // else
            // {
            //     Answers.Remove(foundAnswer);
            //     return NoContent();
            // }
            
            // TODO Ingen nullhantering!!
            _answerService.DeleteAnswer(answer);
            return Ok();

        }
    }
