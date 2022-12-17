using System;
using Quiz_API.Models;
using Quiz_API.Repositories;

namespace Quiz_API
{
    // Add more methods, or remove, according to QuizAdapter
    public interface IQuizAdapter
	{
        //public QuizModel GetQuiz(Guid id);

        public Task<QuizModel?> GetQuiz();
        public QuizSolution EvaluateQuizAnswer(QuizAnswer quizAnswer);


        public QuizModel? GetRandomQuizFromDb();
        //public QuizModel? GetRandomQuizFromDb();

        //public QuizModel GetOneRandomQuiz();

        // Finns quizzen i vår databas? I Service? 
        public bool DoesQuizExist(Guid id);

        public void Post(QuizModel quiz);

        public void Put(QuizModel quiz);

        public void Delete(QuizModel quiz);
    }
}

