namespace Quiz_API.Models;

public class AnswerAlternative
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Answer { get; set; }
    public bool IsCorrectAnswer { get; set; }

    
    public AnswerAlternative(string answer, Guid questionId, bool isCorrectAnswer )
    {
        Id = Guid.NewGuid();
        Answer = answer;
        QuestionId = questionId;
        IsCorrectAnswer = isCorrectAnswer;
    }
    
}