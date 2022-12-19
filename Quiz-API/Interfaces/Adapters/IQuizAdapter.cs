using System;
using Quiz_API.Models;
using Quiz_API.Repositories;

namespace Quiz_API
{
    public interface IQuizAdapter
	{
        public Question? GetQuestionById(Guid Id);
        public Answer? GetAnswerById(Guid Id);
        public QuizModel? GetRandomQuizFromDb();
        public bool DoesQuizExist(Guid id);
        public void Post(QuizModel quiz);
        public void Put(QuizModel quiz);
        public void Delete(QuizModel quiz);
    }
}

