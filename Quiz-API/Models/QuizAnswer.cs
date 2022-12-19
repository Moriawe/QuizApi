using System;
namespace Quiz_API.Models
{
	public class QuizAnswer
	{
        Guid Id { get; set; }
        public Guid QuestionId { get; set; }
		public Answer? Answer { get; set; }

	}
}

