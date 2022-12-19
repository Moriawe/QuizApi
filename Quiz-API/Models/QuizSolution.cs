using System;
using Quiz_API.Models;

namespace Quiz_API.Models
{
	public class QuizSolution
	{
        Guid Id { get; set; }
        public Question? Question { get; set; }
        public Answer? Answer { get; set; }
        public bool WasAnswerCorrect { get; set; }

        public QuizSolution()
		{
			Id = Guid.NewGuid();
        }

        public QuizSolution(Question question, Answer answer, bool wasAnswerCorrect)
        {
            Id = Guid.NewGuid();
            Question = question;
            Answer = answer;
            WasAnswerCorrect = wasAnswerCorrect;
        }
    }
}

