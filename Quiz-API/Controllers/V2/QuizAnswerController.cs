using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Services;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz_API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuizAnswerController : ControllerBase
    {
        private IQuizService _quizService;

        public QuizAnswerController(IQuizService quizService)
        {
            _quizService = quizService;
        }


        // POST api/values
        [EnableCors]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizSolution))]
        public IActionResult PostAnswer(QuizAnswer quizAnswer)
        {
            return Ok(_quizService.EvaluateQuizAnswer(quizAnswer));
        }
    }

}

