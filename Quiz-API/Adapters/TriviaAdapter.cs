using Quiz_API.Models;
using Quiz_API.Repositories;

namespace Quiz_API.Adapters;

// Skall hantera kommunikationen med Trivia repot.
/*public class TriviaAdapter
{
    private TriviaRepository _triviaRepository;

    private TriviaModel triviaModel;
    private QuizModel? quizmodel;
    public TriviaAdapter()
    {
        _triviaRepository = new TriviaRepository();
    }

    public async Task<QuizModel> GetOneTriviaQuiz()
    {
        var response = await _triviaRepository.GetTriviaQuiz();
        Console.WriteLine(response);
        QuizModel responseQuiz;
        
         foreach (TriviaModel quiz in response)
         {  
             List<Answer> Answers = new List<Answer>();
             Answers.Add(quiz.CorrectAnswer, quiz.Id, true);
             
             foreach (string answer in quiz.IncorrectAnswers)
             {
                 Answers.Add(new Answer(answer, quiz.Id, false));
             }

             responseQuiz = new QuizModel(quiz.Category, Answers, quiz.Question);
         }

         return responseQuiz;
    }
}*/