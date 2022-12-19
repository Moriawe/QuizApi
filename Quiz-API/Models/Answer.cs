using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_API.Models
{

    public class Answer
    {
        public Guid Id { get; set; }
        public string? AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }

        //[ForeignKey(nameof(QuestionId))]
        public Guid QuestionId { get; set; }

        public Answer()
        {
            Id = Guid.NewGuid();
        }


        public Answer(string answer, Guid questionId, bool isCorrectAnswer)
        {
            Id = Guid.NewGuid();
            AnswerText = answer;
            QuestionId = questionId;
            IsCorrectAnswer = isCorrectAnswer;
        }
    }

}