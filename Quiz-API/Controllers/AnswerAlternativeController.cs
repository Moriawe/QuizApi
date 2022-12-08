using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Quiz_API.Controllers;

    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AnswerAlternativeController : Controller
    {
        // MOCK Storage:
        static List<AnswerAlternative> Answers = new List<AnswerAlternative>();


        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<AnswerAlternative>))]
        public IActionResult Get()
        {
            return Ok(Answers);
        }

     
        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AnswerAlternative))]
        public IActionResult Get(string id)
        {
            List<AnswerAlternative> AnswerAlternatives = new List<AnswerAlternative>();
            
            if (Answers == null)
            {
                return NotFound();
            }
            
            foreach (var answer in Answers)
            {
                if (answer.QuestionId == id)
                {
                    AnswerAlternatives.Add(answer);
                }
            }
            return Ok(AnswerAlternatives);
        }
        

        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<AnswerAlternative>))]
        public IActionResult Post([FromBody] AnswerAlternative answer)
        {
            Answers.Add(answer);
            return Ok(Answers);
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<AnswerAlternative>))]
        public IActionResult Put([FromBody] AnswerAlternative answer)
        {
            var foundAnswer = Answers.Where(x => x.Id == answer.Id).FirstOrDefault();
            if (foundAnswer == null)
            {
                return NotFound();
            }
            else
            {
                Answers.Remove(foundAnswer);
                Answers.Add(answer);
                return Ok(Answers);
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public IActionResult Delete([FromBody] AnswerAlternative answer)
        {
            var foundAnswer = Answers.Where(x => x.Id == answer.Id).FirstOrDefault();
            if (foundAnswer == null)
            {
                return NotFound();
            }
            else
            {
                Answers.Remove(foundAnswer);
                return NoContent();
            }

        }
    }
