using System;
namespace Quiz_API.Models;
{
	public class QuizAnswer
	{
        Guid Id { get; set; }
        Guid QuestionId { get; set; }
        Guid AnswerId { get; set; }

        public QuizAnswer()
		{
		}
	}
}

