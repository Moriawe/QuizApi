using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Quiz_API.Controllers;

    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuizController : Controller
    {
        private QuizService _quizService;
        
        public QuizController(QuizService quizService)
        {
        _quizService = quizService;
        }
        
        // GET: api/values
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizModel))]
        public IActionResult Get()
        {
            return Ok(_quizService.GetOneDbQuiz());
        }
        
        // POST api/values
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<QuizModel>))]
        public IActionResult Post([FromBody] QuizModel quizModel)
        {
            return Ok(_quizService.AddQuizToDatabase(quizModel));
        }
     
        // // GET api/values/5
        // [HttpGet("{limit}")]
        // [SwaggerResponse((int)HttpStatusCode.NotFound)]
        // [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Answer))]
        // public IActionResult Get(int limit)
        // {
        //    return Ok(_quizService);
        // }

    }
