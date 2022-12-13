using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Adapters;

// Skall pussla ihop Answer och Question modellerna
public class QuizAdapter
{
    private QuizDatabaseContext _context;

    private Answer Answer { get; set; }
    private Question question { get; set; }
    private QuizModel quizmodel { get; set; }
    public QuizAdapter()
    {
        _context = new QuizDatabaseContext();
    }
    
    // Skall ta emot ett ID och skicka tillbaka en quizmodel med rätt ID
    public QuizModel getQuiz(Guid id)
    {
        Question question;
        List<Answer> listOfAnswers;
        QuizModel responseQuiz;
        
        // Hämtar hem rätt fråga OCH svarsalternativen till den frågan
        question = _context.Questions.Where(x => x.Id == id).FirstOrDefault();
        listOfAnswers = _context.Answers.Where(answer => answer.QuestionId == id).ToList();
        
        Answer correctAnswer = listOfAnswers.Where(x => x.IsCorrectAnswer == true).FirstOrDefault();
        List<Answer> inCorrectAnswers = listOfAnswers.Where(x => x.IsCorrectAnswer == false).ToList();
        
        responseQuiz = new QuizModel(question.Category, correctAnswer, inCorrectAnswers, question.Text);

        return responseQuiz;
    }

    // Finns quizzen i vår databas?
    public bool doesQuizExist(Guid id)
    {
        if (_context.Questions.Any(x => x.Id == id))
            //(Array.Exists(_context.Questions, Question => Question.Id == id))
        {
            return true;
        }

        return false;
    }
    
    //Save quiz to database
    
}