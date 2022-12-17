using Quiz_API.Adapters;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Services;

// Skall bli en stor mastodont fil som hanterar all logic i hela applikationen
public class QuizService : IQuizService
{

    private IQuizAdapter _quizAdapter;
    private TriviaAdapter _triviaAdapter;
    public QuizService(IQuizAdapter quizAdapter, TriviaAdapter triviaAdapter)
    {
        _quizAdapter = quizAdapter;
        _triviaAdapter = triviaAdapter;
    }
    
    //// Slumpa vilken väg den skall hämta en quiz
    //public QuizModel GetQuiz()
    //{
        
    //    return (quizModel);
    //}

    // Hämta en quiz som innehåller 1 fråga och 4 svarsalternativ från QuizAdapter
    //public QuizModel GetDbQuiz(Guid id)
    //{
    //    QuizModel DbQuiz = _quizAdapter.GetQuiz(id);
    //    return (DbQuiz);
    //}

    public QuizModel? GetDbQuiz()
    {
        QuizModel? DbQuiz = _quizAdapter.GetRandomQuizFromDb();
        return DbQuiz;
    }

    //public async Task<QuizModel> GetQuiz()
    //{
    //    return (await _triviaAdapter.GetOneTriviaQuiz());
    //}

    public async Task<QuizModel?> GetQuiz()
    {
        //var triviaQuiz = GetQuizFromTrivia();
        //var dbQuiz = _quizAdapter.GetRandomQuizFromDb();
        var random = new Random();
        int source = random.Next(2); // 2 sources: Trivia and DB.
        Console.WriteLine($"__________source: {source}");

        //Console.WriteLine($"__________triviaQuiz.GetType: {triviaQuiz.GetType()}");


        if (source == 0)
        {
            var triviaQuiz = (await _triviaAdapter.GetOneTriviaQuiz());
            if (!DoesQuizExistinDb(triviaQuiz.Id))
            {
                AddQuizToDatabase(triviaQuiz);
            }
            return triviaQuiz;
        }
        Console.WriteLine($"__________ From Database");

        return _quizAdapter.GetRandomQuizFromDb();

        //return (await _triviaAdapter.GetOneTriviaQuiz());

        //return  dbQuiz;
    }

    //// Hämta en quiz som innehåller 1 fråga och 4 svarsalternativ från TriviaAdapter
    public async Task<QuizModel> GetTriviaQuiz()
    {
        return (await _triviaAdapter.GetOneTriviaQuiz());
    }
    
    public bool isAnswerCorrect(Answer answer)
    {
        if (answer.IsCorrectAnswer)
        {
            return true;
        }
        return false;
    }
    
    public bool DoesQuizExistinDb(Guid id)
    {
        return _quizAdapter.DoesQuizExist(id);
    }
    
    public QuizModel AddQuizToDatabase(QuizModel quiz)
    {
        _quizAdapter.Post(quiz);
        return quiz;
    }

    public void UpdateQuizInDatabase(QuizModel quiz)
    {
        _quizAdapter.Put(quiz);
    }
    public void DeleteQuizFromDatabase(QuizModel quiz)
    {
        _quizAdapter.Delete(quiz);
    }
}