using System;
using Quiz_API.Models;
using Quiz_API.Repositories;

namespace Quiz_API
{
	public interface IQuizAdapter
	{
        public QuizModel GetQuiz(Guid id);

        public QuizModel GetOneRandomQuiz();

        // Finns quizzen i vår databas? I Service? 
        public bool DoesQuizExist(Guid id);

        public void Post(QuizModel quiz);

        public void Put(QuizModel quiz);

        public void Delete(QuizModel quiz);
    }
}

