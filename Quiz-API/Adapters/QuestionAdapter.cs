using System;
using Microsoft.EntityFrameworkCore;
using Quiz_API.Models;
using Quiz_API.Repositories;

namespace Quiz_API.Adapters
{
    public class QuestionAdapter
    {
        private IQuestionRepository _repository;

        public QuestionAdapter(IQuestionRepository repository)
        {
            _repository = repository;
        }


        public List<Question> GetAllQuestions()
        {
            return _repository.Get();
        }

        public Question? GetQuestionById(Guid Id)
        {
            return _repository.Get(Id);
        }

        public Question SaveNewQuestion(Question question)
        {
            return _repository.Post(question);
        }

        public Question? UpdateQuestion(Question question)
        {
            return _repository.Put(question);
        }

        public bool DeleteQuestion(Question question)
        {
            return _repository.Delete(question);
        }

    }
}

