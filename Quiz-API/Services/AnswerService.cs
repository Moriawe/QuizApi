using Microsoft.AspNetCore.Http.HttpResults;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Services;

public class AnswerService
{
    private AnswerAdapter _adapter;

    public AnswerService(AnswerAdapter adapter)
    {
        _adapter = adapter;
    }


    public List<Answer> GetAllAnswers()
    {
        return _adapter.GetAllAnswers();
    }

    // Begär en string ID just nu, kan behöva ändras till Guid.
    public List<Answer> GetAnswerByID(Guid id)
    {
        List<Answer> listOfAnswers;
        listOfAnswers = _adapter.GetAllAnswers().Where(answer => answer.QuestionId == id).ToList();
        return listOfAnswers;
    }

    // Skall denna returnera ALLA answers till den frågan eller bara den man postade?
    public Answer PostAnswer(Answer answer)
    {
        _adapter.SaveNewAnswer(answer);
        return (answer);
    }

    public bool PutAnswer(Answer answer)
    {
        var foundAnswer = _adapter.GetAllAnswers().Where(x => x.Id == answer.Id).FirstOrDefault();
        if (foundAnswer == null)
        {
            return false;
        }
        _adapter.DeleteAnswer(foundAnswer);
        _adapter.SaveNewAnswer(answer);
        return true;
    }

    public bool DeleteAnswer(Guid id)
    {
        var foundAnswer = _adapter.GetAllAnswers().Where(x => x.Id == id).FirstOrDefault();
        if (foundAnswer == null)
        {
            return false;
        }
        _adapter.DeleteAnswer(foundAnswer);
        return true;
    }

}