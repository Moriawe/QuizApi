using Quiz_API.Models;

namespace Quiz_API.Services;

// Skall bli en stor mastodont fil som hanterar all logic i hela applikationen
public class QuizService
{
    public QuizService()
    {
        
    }
    
    // Slumpa vilken väg den skall hämta en quiz
    public QuizModel GetQuiz()
    {
        return (quizModel);
    }

    // Hämta en quiz som innehåller 1 fråga och 4 svarsalternativ från QuizAdapter
    public QuizModel GetDBQuiz()
    {
        return (quizModel);
    }
    
    // Hämta en quiz som innehåller 1 fråga och 4 svarsalternativ från TriviaAdapter
    public QuizModel GetTriviaQuiz()
    {
        return (quizModel);
    }
    
    // Kolla om quizzen redan finns i databasen
    public checkIfQuizExists()
    {
        
    }
    
    // Lägg till quizzen i databasen
    public AddQuizToDatabase()
    {
        
    }
}