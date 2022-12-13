using System;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Adapters;

namespace Quiz_API.Services
{

    // Maybe QuisService instead
    // Build ViewModel that QuizController can use
    public class QuestionService
    {
        //private QuizDatabaseContext Context;
        private QuestionAdapter _adapter;


        public QuestionService()
        {
            _adapter = new QuestionAdapter();
        }



        public List<Question> Get()
        {
            return _adapter.GetAllQuestions();
        }

        public Question? Get(Guid Id)
        {
            return _adapter.GetQuestionById(Id);
        }

        public Question Post(Question question)
        {
            return _adapter.SaveNewQuestion(question);
        }

        public Question? Put(Question question)
        {
            return _adapter.UpdateQuestion(question);
        }

        public bool Delete(Question question)
        {
            return _adapter.DeleteQuestion(question);
        }



    }
}
