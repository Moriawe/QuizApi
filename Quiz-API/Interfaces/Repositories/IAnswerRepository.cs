using System;
using Microsoft.EntityFrameworkCore;
using Quiz_API.Models;

namespace Quiz_API
{
	public interface IAnswerRepository
	{
        //public List<Answer> Get();
        //public Answer? Get(Guid Id);
        //public List<Answer> GetAnswers(Guid questionId);
        //public Answer Post(Answer answer);
        //public Answer? Put(Answer answer);
        //public bool Delete(Answer answer);


        public List<Answer> Get();

        public Answer? Get(Guid Id);

        public List<Answer> GetAnswerByQuestionId(Guid questionId);

        public Answer Post(Answer answer);

        public Answer? Put(Answer answer);

        public bool Delete(Answer answer);
    }
}

