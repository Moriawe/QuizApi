namespace Quiz_API.Services;

public class QuizService
{
    public QuizService()
    {
        
    }

    public GetQuiz()
    {
        using (var context = new TriviaRepository())
        {
            return (context.Answers.ToList());
        }
    }
}