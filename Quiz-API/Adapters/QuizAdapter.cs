using Quiz_API.Models;
using Quiz_API.Persistance;
using Quiz_API.Repositories;

namespace Quiz_API.Adapters;

// Skall pussla ihop Answer och Question modellerna
public class QuizAdapter
{
    private QuestionRepository _questionRepository;
    private AnswerRepository _answerRepository;
    
    public QuizAdapter(QuestionRepository questionRepository)
    {
        _questionRepository = new QuestionRepository();
        _answerRepository = new AnswerRepository();
    }
    
    // Skall ta emot ett ID och skicka tillbaka en quizmodel med rätt ID
    public QuizModel GetQuiz(Guid id)
    {
        Question question = _questionRepository.Get(id);
        List<Answer> listOfAnswers = _answerRepository.GetAnswers(id);

        QuizModel responseQuiz = new QuizModel(question.Category, listOfAnswers, question.Text);

        return responseQuiz;
    }

    public QuizModel GetOneRandomQuiz()
    {
        List<Question> Questions = _questionRepository.Get();
        var random = new Random();
        int index = random.Next(Questions.Count);
        var chosenQuestion = Questions[index];
        Console.WriteLine(chosenQuestion);


        List<Answer> Answers = _answerRepository.GetAnswers(chosenQuestion.Id);

        QuizModel responseQuiz = new QuizModel(chosenQuestion.Category, Answers, chosenQuestion.Text);
        return responseQuiz;
    }
    
    //public QuizModel GetOneCategoryQuiz(Category category)
    //{
    //    
    //}

    // Finns quizzen i vår databas?
    public bool DoesQuizExist(Guid id)
    {
        if (_questionRepository.Get().Any(x => x.Id == id))
        {
            return true;
        }

        return false;
    }
    
    //Save quiz to database
    
}