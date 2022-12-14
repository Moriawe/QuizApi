using System;
using Microsoft.EntityFrameworkCore;
using Quiz_API.Models;

namespace Quiz_API
{
	public interface IQuizDatabaseContext
	{
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public int Save();
    }
}

