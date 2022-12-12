namespace Quiz_API.Models;

public class QuizModel
{
    public string Id { get; set; }
    public Category Category { get; set; }
    public Answer CorrectAnswer { get; set; }
    public Answer[] IncorrectAnswers { get; set; }
    public string Question { get; set; }

    public QuizModel(Category category, Answer correctAnswer, Answer[] incorrectAnswers, string question)
    {
        //Id = Guid.NewGuid();
        Category = category;
        CorrectAnswer = correctAnswer;
        IncorrectAnswers = incorrectAnswers;
        Question = question;
    }
}