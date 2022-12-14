using Quiz_API.Adapters;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Services;

// Skall bli en stor mastodont fil som hanterar all logic i hela applikationen
public class QuizService
{
    private QuizAdapter _quizAdapter;
    public QuizService(QuizAdapter quizAdapter)
    {
        _quizAdapter = quizAdapter;
    }
    
    //// Slumpa vilken väg den skall hämta en quiz
    //public QuizModel GetQuiz()
    //{
        
    //    return (quizModel);
    //}

    // Hämta en quiz som innehåller 1 fråga och 4 svarsalternativ från QuizAdapter
    public QuizModel GetDbQuiz(Guid id)
    {
        QuizModel DbQuiz = _quizAdapter.GetQuiz(id);
        return (DbQuiz);
    }

    public QuizModel GetOneDbQuiz()
    {
        QuizModel DbQuiz = _quizAdapter.GetOneRandomQuiz();
        return (DbQuiz);
    }

    
    //// Hämta en quiz som innehåller 1 fråga och 4 svarsalternativ från TriviaAdapter
    //public QuizModel GetTriviaQuiz()
    //{
    //    return (quizModel);
    //}
    
    // Kolla om användaren svarat rätt
    public bool isAnswerCorrect(Answer answer)
    {
        
        //using (var context = new QuizDatabaseContext())
        //{
            if (answer.IsCorrectAnswer)
            {
                return true;
            }
            return false;
        //}
       
    }
    
    public bool checkIfQuizExistsinDb(Guid id)
    {
        return _quizAdapter.DoesQuizExist(id);
    }
    
    // Lägg till quizzen i databasen
    public void AddQuizToDatabase(QuizModel quiz)
    {
        _quizAdapter.Post(quiz);
    }
}