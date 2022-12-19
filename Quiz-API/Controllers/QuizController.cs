using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Repositories;
using Quiz_API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Quiz_API.Controllers
{

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


        [EnableCors]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizModel))]
        public async Task<IActionResult> GetQuiz()
        {
            return Ok(await _quizService.GetQuiz());
        }
    }
}
