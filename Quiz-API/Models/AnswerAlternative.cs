namespace Quiz_API.Models;

public class AnswerAlternative
{
    public string Id { get; set; }
    public string QuestionId { get; set; }
    public string Answer { get; set; }
    public bool IsCorrectAnswer { get; set; }

    
    public AnswerAlternative(string answer, string questionId, bool isCorrectAnswer )
    {
        //Id = Guid.NewGuid();
        Answer = answer;
        QuestionId = questionId;
        IsCorrectAnswer = isCorrectAnswer;
    }
    
}