using System;
using Microsoft.EntityFrameworkCore;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API.Repositories
{
    public class QuestionRepository
    {
        private IQuizDatabaseContext _context;


        public QuestionRepository(IQuizDatabaseContext context)
        {
            _context = context;
        }



        public List<Question> Get()
        {
            return _context.Questions.ToList();
        }

        public Question? Get(Guid Id)
        {
            return _context.Questions.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Question Post(Question question)
        {
            var addedQuestion =
                _context.Questions.Add(question);

            var updateCount =
            _context.Save();
            return addedQuestion.Entity;
        }

        public Question? Put(Question question)
        {
            var questionToUpdate = _context.Questions.Where(x => x.Id == question.Id).FirstOrDefault();

            if (questionToUpdate != null)
            {
                // Need to do this:
                questionToUpdate.Id = question.Id;
                questionToUpdate.Text = question.Text;
                questionToUpdate.Category = question.Category; ;

                var updatedQuestion = _context.Questions.Update(questionToUpdate);

                var updateCount =
                _context.Save();
                return updatedQuestion.Entity;
            }
            return null;
        }

        public bool Delete(Question question)
        {
            var foundQuestion = _context.Questions.Where(x => x.Id == question.Id).FirstOrDefault();

            // inverted if:
            if (foundQuestion == null)
            {
                return false;
            }
            _context.Questions.Remove(foundQuestion);
            _context.Save();
            return true;
        }

    }

}

