using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quiz_API.Models;


namespace Quiz_API.Persistance
{
	public class QuizContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerAlternative> AnswerAlternatives { get; set; }

        public QuizContext()
		{
		}
	}
}

