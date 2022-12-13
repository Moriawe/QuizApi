using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quiz_API.Models;


namespace Quiz_API.Persistance
{

    public class QuizDatabaseContext : DbContext
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

        // c_R_ud
        public Question? GetQuestionById(string id)
        {
            Console.WriteLine("QuizContext GetQuestion");
            var question = this.Questions.Where(x => x.Id == id).FirstOrDefault();
            if (question == null)
            {
                return null;
            }
            return question;
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
        public List<Question>? UpdateQuestion(Question question)
        {
            var questionToUpdate = this.Questions.Where(x => x.Id == question.Id).FirstOrDefault();
            Console.WriteLine($"QuizContext UpdatePlayer questionToUpdate: {questionToUpdate}");

            if (questionToUpdate != null)
            {
                // Need to do this:
                questionToUpdate.Id = question.Id;
                questionToUpdate.Text = question.Text;
                questionToUpdate.Category = question.Category; ;

                Console.WriteLine("QuizContext updatedQuestion");
                var updatedQuestion = this.Questions.Update(questionToUpdate);

                var updateCount =
                this.Save();
                Console.WriteLine($"QuizContext UpdateQuestion updateCount: {updateCount}");
                return this.GetQuestions();
            }
            Console.WriteLine($"QuizContext UpdateQuestion questionToUpdate IS null");
            return null;

        }

        // cru_D
        public bool DeleteQuestion(Question question)
        {
            Console.WriteLine("QuizContext DeleteQuestion");
            var foundQuestion = this.Questions.Where(x => x.Id == question.Id).FirstOrDefault();

            // inverted if:
            if (foundQuestion == null)
            {
                return false;
            }
            this.Questions.Remove(foundQuestion);
            this.Save();
            return true;
        }

        public int Save()
        {
            Console.WriteLine("QuizContext Save");
            return this.SaveChanges();
        }




    }
}

