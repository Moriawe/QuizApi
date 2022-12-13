namespace Quiz_API.Models;

// Klassen vi vill exponera utåt till vårt API
public class QuizModel
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public List<Answer> IncorrectAnswers { get; set; }
    public string Question { get; set; }

    public QuizModel(string category, List<Answer> incorrectAnswers, string question)
    {
        Id = Guid.NewGuid();
        Category = category;
        IncorrectAnswers = incorrectAnswers;
        Question = question;
    }
}