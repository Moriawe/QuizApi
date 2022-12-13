namespace Quiz_API.Models;

// Klassen vi vill exponera utåt till vårt API
public class QuizModel
{
    public string Id { get; set; }
    public Category Category { get; set; }
    // Skall rätt svar också vara en lista? ifall det finns flera rätt svar?
    public Answer CorrectAnswer { get; set; }
    public List<Answer> IncorrectAnswers { get; set; }
    public string Question { get; set; }

    public QuizModel(Category category, Answer correctAnswer, List<Answer> incorrectAnswers, string question)
    {
        //Id = Guid.NewGuid();
        Category = category;
        CorrectAnswer = correctAnswer;
        IncorrectAnswers = incorrectAnswers;
        Question = question;
    }
}