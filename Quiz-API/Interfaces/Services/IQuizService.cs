﻿using System;
using Quiz_API.Adapters;
using Quiz_API.Models;

namespace Quiz_API
{
	public interface IQuizService
	{
        public QuizModel GetDbQuiz(Guid id);
        public QuizModel GetOneDbQuiz();
        public Task<QuizModel> GetTriviaQuiz();
        public bool isAnswerCorrect(Answer answer);
        public bool checkIfQuizExistsinDb(Guid id);
        public QuizModel AddQuizToDatabase(QuizModel quiz);
        public void UpdateQuizInDatabase(QuizModel quiz);
        public void DeleteQuizFromDatabase(QuizModel quiz);
    }
}

