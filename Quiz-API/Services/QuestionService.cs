using System;
using Microsoft.AspNetCore.Mvc;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Services
{
    public class QuestionService
    {
        private QuizDatabaseContext Context;


        public QuestionService()
        {
            Context = new QuizDatabaseContext();
        }


        public List<Question> Get()
        {
            return Context.GetQuestions();
        }

        public Question? Get(string Id)
        {
            return Context.GetQuestionById(Id);
        }

        public List<Question> Post(Question question)
        {
            return Context.SaveQuestion(question);
        }

        public List<Question>? Put(Question question)
        {
            return Context.UpdateQuestion(question);
        }

        public bool Delete(Question question)
        {
            return Context.DeleteQuestion(question);
        }



    }
}
