using System;
using Microsoft.EntityFrameworkCore;
using Quiz_API.Models;

namespace Quiz_API
{
	public interface IQuestionRepository
	{
        public List<Question> Get();
        public Question? Get(Guid Id);
        public Question Post(Question question);
        public Question? Put(Question question);
        public bool Delete(Question question);
    }
}

