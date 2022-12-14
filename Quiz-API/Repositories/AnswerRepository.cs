using System;
using Quiz_API.Models;
using Quiz_API.Persistance;

namespace Quiz_API
{
    public class AnswerRepository
    {
        private IQuizDatabaseContext _context;

        public AnswerRepository(IQuizDatabaseContext context)
        {
            _context = context;
        }


        public List<Answer> Get()
        {
            return _context.Answers.ToList();
        }

        public Answer? Get(Guid Id)
        {
            return _context.Answers.Where(x => x.Id == Id).FirstOrDefault();
        }
        
        public List<Answer> GetAnswers(Guid questionId)
        {
            return _context.Answers.Where(answer => answer.QuestionId == questionId).ToList();
        }

        public Answer Post(Answer answer)
        {
            var addedAnswer =
                _context.Answers.Add(answer);

            var updateCount =
            _context.Save();
            return addedAnswer.Entity;
        }

        public Answer? Put(Answer answer)
        {
            var answerToUpdate = _context.Answers.Where(x => x.Id == answer.Id).FirstOrDefault();

            if (answerToUpdate != null)
            {
                // Need to do this:
                answerToUpdate.Id = answer.Id;
                answerToUpdate.AnswerText = answer.AnswerText;
                answerToUpdate.IsCorrectAnswer = answer.IsCorrectAnswer; ;

                var updatedAnswer = _context.Answers.Update(answerToUpdate);

                var updateCount =
                _context.Save();
                return updatedAnswer.Entity;
            }
            return null;
        }

        public bool Delete(Answer answer)
        {
            var foundAnswer = _context.Answers.Where(x => x.Id == answer.Id).FirstOrDefault();

            // inverted if:
            if (foundAnswer == null)
            {
                return false;
            }
            _context.Answers.Remove(foundAnswer);
            _context.Save();
            return true;
        }




    }

}

