﻿using System;
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
            //this.Database.EnsureCreated(); // Create the (sqlite) database if it does not exist.
        }

        // c_R_ud
        public List<Question> GetQuestions()
        {
            Console.WriteLine("QuizContext GetQuestions");
            var questions = this.Questions.ToList();
            return questions;
        }

        // C_rud
        public List<Question> SaveQuestion(Question question)
        {
            var addedQuestion =
            this.Questions.Add(question);
            Console.WriteLine($"QuizContext SaveQuestion addedQuestion: {addedQuestion}");


            //Commit (save) changes to the database.
            var updateCount =
            this.Save();
            Console.WriteLine($"QuizContext SaveQuestion updateCount: {updateCount}");

            return this.GetQuestions();
        }

        // cr_U_d
        public List<Question>? UpdatePlayer(Question question)
        {
            var questionToUpdate = this.Questions.Where(x => x.Id == question.Id).FirstOrDefault();
            Console.WriteLine($"QuizContext UpdatePlayer questionToUpdate: {questionToUpdate}");

            if (playerToUpdate != null)
            {
                // Need to do this:
                playerToUpdate.Id = player.Id;
                playerToUpdate.Name = player.Name;
                playerToUpdate.Age = player.Age;
                playerToUpdate.Health = player.Health;
                playerToUpdate.Strength = player.Strength;

                Console.WriteLine("GameDatabaseContext updatedPlayer");
                var updatedPlayer = this.Players.Update(playerToUpdate);

                var updateCount =
                this.Save();
                Console.WriteLine($"GameDatabaseContext UpdatePlayer updateCount: {updateCount}");
                return this.GetPlayers();
            }
            Console.WriteLine($"GameDatabaseContext UpdatePlayer playerToUpdate IS null");
            return null;

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

