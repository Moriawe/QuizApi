using System;
using Quiz_API.Models;

namespace Quiz_API.Models
{
	public class QuizSolution
	{
        Guid Id { get; set; }
        Question Question { get; set; }
        Answer Answer { get; set; }

        public QuizSolution()
		{
			Id = Guid.NewGuid();
        }

        public QuizSolution(Question question, Answer answer)
        {
            Id = Guid.NewGuid();
            Question = question;
            Answer = answer;
        }
    }
}

