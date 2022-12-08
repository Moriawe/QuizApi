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


        public List<Question> GetQuestions()
        {
            Console.WriteLine("QuizContext GetQuestions");
            var questions = this.Questions.ToList();
            return questions;
        }


        public List<Question> SaveQuestion(Question question)
        {
            var addedQuestion =
            this.Questions.Add(question);
            Console.WriteLine($"QuizContext SaveQuestion addedQuestion: {addedQuestion}");


            //Commit (save) changes to the database.
            var updateCount =
            this.Save();
            Console.WriteLine($"GameDatabaseContext SavePlayer updateCount: {updateCount}");

            return this.GetQuestions();
        }

        public int Save()
        {
            Console.WriteLine("QuizContext Save");

            // "No database provider has been configured for this DbContext.
            // A provider can be configured by overriding the 'DbContext.OnConfiguring' method
            // or by using 'AddDbContext' on the application service provider.
            // If 'AddDbContext' is used, then also ensure that your DbContext type accepts a
            // DbContextOptions<TContext> object in its constructor and passes it to
            // the base constructor for DbContext."

            return 0;
            //return this.SaveChanges();
        }


    }
}

