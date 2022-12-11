using Microsoft.AspNetCore.Http.HttpResults;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Services;

public class AnswerService
{

    public AnswerService()
    {
        
    }

    // Vill man någonsin ha ALLA svaren? 
    public List<Answer> GetAllAnswers()
    {
        using (var context = new QuizContext())
        {
            // Behöver omformateras från DbSet till en lista.
            return context.Answers;
        }
    }
    
    // Begär en string ID just nu, kan behöva ändras till Guid.
    public List<Answer> GetAnswers(string id)
    {
        List<Answer> listOfAnswers;
        using (var context = new QuizContext())
        {
            listOfAnswers = context.Answers.Where(answer => answer.QuestionId == id).ToList();
        }

        return listOfAnswers;
    }
    
    // Skall denna returnera ALLA answers till den frågan eller bara den man postade?
    public Answer PostAnswer(Answer answer)
    {
        using (var context = new QuizContext())
        {
            context.Answers.Add(answer);
        }

        return (answer);
    }

    public bool PutAnswer(Answer answer)
    {
        using (var context = new QuizContext())
        {
            var foundAnswer = context.Answers.FirstOrDefault(x => x.Id == answer.Id);
            if (foundAnswer == null)
            {
                return false;
            }
            context.Answers.Remove(foundAnswer);
            context.Answers.Add(answer);
            return true;
        }
        
    }

    public bool DeleteAnswer(string id)
    {
        using (var context = new QuizContext())
        {
            var foundAnswer = context.Answers.FirstOrDefault(x => x.Id == id);
            if (foundAnswer == null)
            {
                return false;
            }
            context.Answers.Remove(foundAnswer);
            return true;
        }
    }
    
}