﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_API.Models;

public class Answer
{
    public string Id { get; set; }
    public string AnswerText { get; set; }
    public bool IsCorrectAnswer { get; set; }
    
    //[ForeignKey(nameof(QuestionId))]
    public string QuestionId { get; set; }
    //public Question Question { get; set; }
    
    // Jennie: Jag behövde tillfälligt bortkommentera nedanstående konstruktor, för att få projektet att bygga. Är osäker på varför.
    //public Answer(string answer, string questionId, bool isCorrectAnswer )
    //{
    //    //Id = Guid.NewGuid();
    //    AnswerText = answer;
    //    QuestionId = questionId;
    //    IsCorrectAnswer = isCorrectAnswer;
    //}

    
}