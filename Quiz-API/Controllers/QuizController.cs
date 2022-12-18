using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Repositories;
using Quiz_API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Quiz_API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class QuizController : ControllerBase
{
        private IQuizService _quizService;
        private TriviaRepository _triviaRepository = new();
        
        public QuizController(IQuizService quizService)
        {
        _quizService = quizService;
        }


    [EnableCors("Policy1")]
    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizModel))]
    public async Task<IActionResult> GetQuiz()
    {
        return Ok(await _quizService.GetQuiz());
    }

    //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizModel))]
    //public async Task<IActionResult> GetTrivia()
    //{
    //    return Ok(await _quizService.GetTriviaQuiz());
    //}

    // GET: api/values
    [HttpGet("Database")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizModel))]
         public IActionResult GetDatabase()
        {
            return Ok(_quizService.GetDbQuiz());
        } 
        
        // GET: api/values
        [HttpGet("TriviaRepo")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(TriviaModel))]
        public async Task<IActionResult> GetTriviaModel()
        {
            return Ok(await _triviaRepository.GetTriviaAsync());
            //return Ok(await _quizService.GetTriviaQuiz());
        }
        
        // GET: api/values
        [HttpGet("Trivia")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizModel))]
        public async Task<IActionResult> GetTrivia()
        {
            return Ok(await _quizService.GetTriviaQuiz());
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
