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


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz_API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuestionController : Controller
    {
        private QuizContext Context = new QuizContext(); // Should recieve as argument in constructor.

        // MOCK Storage:
        static List<Question> Questions = new List<Question>();


        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Get()
        {
            return Ok(Questions);

            //Context:
            //return Ok(Context.GetQuestions());

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

            //Context:
            //var questionList = Context.GetQuestions().Where(x => x.Id == id);
            //if (questionList.Count() == 0)
            //{
            //    return NotFound("Id not found");
            //}
            //return Ok(questionList.First());

        }

        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Question>))]
        public IActionResult Post([FromBody] Question question)
        {
            Questions.Add(question);
            return Ok(Questions);

            //Context:
            //return Ok(Context.SaveQuestion(question));
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

            //Context:
            //var questions = Context.UpdateQuestion(question); // This returns too late, I think
            //Console.WriteLine($"QuestionController PUT question: {question}");

            //if (question == null)
            //{
            //    Console.WriteLine($"QuestionController PUT question == null");
            //    return NotFound("Question not found");
            //}
            //Console.WriteLine($"QuestionController PUT question is NOT null");
            //return Ok(questions);


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

            //Context:
            //var success = Context.DeleteQuestion(question);
            //if (!success)
            //{
            //    return NotFound();
            //}
            //return NoContent();

        }
    }
}

