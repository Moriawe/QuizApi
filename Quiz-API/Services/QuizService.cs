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


    public QuizModel? GetDbQuiz()
    {
        QuizModel? DbQuiz = _quizAdapter.GetRandomQuizFromDb();
        return DbQuiz;
    }


    public async Task<QuizModel?> GetQuiz()
    {
        var random = new Random();
        int source = random.Next(2); // 2 sources: Trivia and DB.

        if (source == 0)
        {
            var triviaQuiz = (await _triviaAdapter.GetOneTriviaQuiz());
            if (!DoesQuizExistinDb(triviaQuiz.Id))
            {
                AddQuizToDatabase(triviaQuiz);
            }
            triviaQuiz.Answers = RandomizeAnswers(triviaQuiz.Answers);

            return triviaQuiz;
        }
        var dbQuiz = _quizAdapter.GetRandomQuizFromDb();
        dbQuiz.Answers = RandomizeAnswers(dbQuiz.Answers);

        return dbQuiz;
    }


    private List<Answer> RandomizeAnswers(List<Answer> answers)
    {
        Random rnd = new Random();
        List<Answer> randomizedAnswers = answers.OrderBy(x => rnd.Next()).ToList();
        answers = randomizedAnswers;
        return answers;
    }


    //// Hämta en quiz som innehåller 1 fråga och 4 svarsalternativ från TriviaAdapter
    public async Task<QuizModel> GetTriviaQuiz()
    {
        return (await _triviaAdapter.GetOneTriviaQuiz());
    }


    public QuizSolution EvaluateQuizAnswer(QuizAnswer quizAnswer)
    {
        var question = _quizAdapter.GetQuestionById(quizAnswer.QuestionId);
        var answer = quizAnswer.Answer;
        var wasAnswerCorrect = answer.IsCorrectAnswer;

        return new QuizSolution(question, answer, wasAnswerCorrect);
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