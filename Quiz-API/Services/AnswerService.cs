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
    
    // Skall denna returnera ALLA answers eller bara den man postade?
    public Answer PostAnswer(Answer answer)
    {
        using (var context = new QuizContext())
        {
            context.Answers.Add(answer);
        }

        return (answer);
    }

    // Behöver returnera ett nullvärde eller NotFound till Controllern
    public Answer PutAnswer(Answer answer)
    {
        Answer foundAnswer;
        using (var context = new QuizContext())
        {
            foundAnswer = context.Answers.FirstOrDefault(x => x.Id == answer.Id);
            if (foundAnswer !== null)
            {
                context.Answers.Remove(foundAnswer);
                context.Answers.Add(answer);
            }
            return foundAnswer;
        }
        
    }

    // Behöver samma som ovan
    public void DeleteAnswer(Answer answer)
    {
        using (var context = new QuizContext())
        {
            var foundAnswer = context.Answers.FirstOrDefault(x => x.Id == answer.Id);
            if (foundAnswer !== null)
            {
                context.Answers.Remove(foundAnswer);
            }

            return;
        }
    }
    
}