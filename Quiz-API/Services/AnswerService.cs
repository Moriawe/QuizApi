using Microsoft.AspNetCore.Http.HttpResults;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Services;

public class AnswerService
{
    private IQuizDatabaseContext _context;

    public AnswerService(IQuizDatabaseContext context)
    {
        _context = context;
    }


    // Vill man någonsin ha ALLA svaren? 
    public List<Answer> GetAllAnswers()
    {
            return _context.Answers.ToList();
    }
    
    // Begär en string ID just nu, kan behöva ändras till Guid.
    public List<Answer> GetAnswers(Guid id)
    {
        List<Answer> listOfAnswers;
            listOfAnswers = _context.Answers.Where(answer => answer.QuestionId == id).ToList();
        return listOfAnswers;
    }
    
    // Skall denna returnera ALLA answers till den frågan eller bara den man postade?
    public Answer PostAnswer(Answer answer)
    {
            _context.Answers.Add(answer);
        return (answer);
    }

    public bool PutAnswer(Answer answer)
    {
            var foundAnswer = _context.Answers.FirstOrDefault(x => x.Id == answer.Id);
            if (foundAnswer == null)
            {
                return false;
            }
            _context.Answers.Remove(foundAnswer);
            _context.Answers.Add(answer);
            return true;
    }

    public bool DeleteAnswer(Guid id)
    {
            var foundAnswer = _context.Answers.FirstOrDefault(x => x.Id == id);
            if (foundAnswer == null)
            {
                return false;
            }
            _context.Answers.Remove(foundAnswer);
            return true;
    }
    
}