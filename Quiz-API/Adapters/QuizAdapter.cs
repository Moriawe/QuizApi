using Quiz_API.Models;
using Quiz_API.Persistance;
using Quiz_API.Repositories;

namespace Quiz_API.Adapters;

// Skall pussla ihop Answer och Question modellerna
public class QuizAdapter
{
    private QuestionRepository _questionRepository;
    private AnswerRepository _answerRepository;
    
    public QuizAdapter(QuestionRepository questionRepository, AnswerRepository answerRepository)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
    }
    
    // Skall det bara finnas en generell get metod som anropas på olika sätt ifrån service? 
    
    // Skall ta emot ett ID och skicka tillbaka en quizmodel med rätt ID
    public QuizModel GetQuiz(Guid id)
    {
        Question question = _questionRepository.Get(id);
        List<Answer> listOfAnswers = _answerRepository.GetAnswers(id);

        QuizModel responseQuiz = new QuizModel(question.Category, question.TriviaId, listOfAnswers, question.Text);

        return responseQuiz;
    }

    public QuizModel GetOneRandomQuiz()
    {
        List<Question> Questions = _questionRepository.Get();
        var random = new Random();
        int index = random.Next(Questions.Count)-1;
        var chosenQuestion = Questions[index];

        List<Answer> Answers = _answerRepository.GetAnswers(chosenQuestion.Id);

        QuizModel responseQuiz = new QuizModel(chosenQuestion.Category, chosenQuestion.TriviaId, Answers, chosenQuestion.Text);
        return responseQuiz;
    }

    // Finns quizzen i vår databas? I Service? 
    public bool DoesQuizExist(Guid id)
    {
        if (_questionRepository.Get().Any(x => x.Id == id))
        {
            return true;
        }

        return false;
    }

    public void Post(QuizModel quiz)
    {
        Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
        _questionRepository.Post(question);
        
        foreach (Answer answer in quiz.Answers)
        {
            _answerRepository.Post(answer);
        }
    }

    public void Put(QuizModel quiz)
    {
        Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
        _questionRepository.Put(question);
        
        foreach (Answer answer in quiz.Answers)
        {
            _answerRepository.Put(answer);
        }
    }
    public void Delete(QuizModel quiz)
    {
        Question question = new Question(quiz.Question, quiz.TriviaId, quiz.Category);
        _questionRepository.Delete(question);
        
        foreach (Answer answer in quiz.Answers)
        {
            _answerRepository.Delete(answer);
        }
    }
    
    
}