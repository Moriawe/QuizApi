using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quiz_API.Models;


namespace Quiz_API.Persistance
{

    public class QuizDatabaseContext : DbContext, IQuizDatabaseContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuizDatabaseContext()
        {
            this.Database.EnsureCreated(); // Create the (sqlite) database if it does not exist.
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=quiz.sqlite");
            Console.WriteLine("QuizDatabaseContext OnConfiguring");
        }



        public int Save()
        {
            Console.WriteLine("QuizContext Save");
            return this.SaveChanges();
        }




    }
}

