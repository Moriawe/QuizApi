﻿using System;
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

namespace Quiz_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class QuizAnswerController : ControllerBase
    {
        private IQuizService _quizService;

        public QuizAnswerController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        //GET: api/values
        //[HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [EnableCors]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(QuizSolution))]
        public IActionResult PostAnswer(QuizAnswer quizAnswer)
        {
            //var result = _quizService.EvaluateQuizAnswer(quizAnswer);
            //Console.WriteLine($"___________ PostAnswer result: {result.Question.Text} wasCorrect: {result.WasAnswerCorrect}");
            return Ok(_quizService.EvaluateQuizAnswer(quizAnswer));
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

