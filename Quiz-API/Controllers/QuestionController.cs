using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz_API
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuestionController : Controller
    {
        // MOCK Storage:
        static List<Question> Questions = new List<Question>();


        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Get()
        {
            return Ok(Questions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Question))]
        public IActionResult Get(string id)
        {
            var question = Questions.Where(x => x.Id == id).FirstOrDefault();
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Post([FromBody] Question question)
        {
            Questions.Add(question);
            return Ok(Questions);
        }

        // PUT api/values/5
        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Put([FromBody] Question question)
        {
            var foundQuestion = Questions.Where(x => x.Id == question.Id).FirstOrDefault();
            if (question == null)
            {
                return NotFound();
            } else
            {
                Questions.Remove(foundQuestion);
                Questions.Add(question);
                return Ok(Questions);
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        public IActionResult Delete([FromBody] Question question)
        {
            var foundQuestion = Questions.Where(x => x.Id == question.Id).FirstOrDefault();
            if (question == null)
            {
                return NotFound();
            }
            else
            {
                Questions.Remove(foundQuestion);
                return NoContent();
            }

        }
    }
}

