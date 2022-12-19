using System;
using Quiz_API.Models;

namespace Quiz_API
{
	public class AnswerAdapter
    {
        private IAnswerRepository _repository;


        public AnswerAdapter(IAnswerRepository repository)
		{
            _repository = repository;
        }


        public List<Answer> GetAllAnswers()
        {
            return _repository.Get();
        }

        public Answer? GetAnswerById(Guid Id)
        {
            return _repository.Get(Id);
        }

        public Answer SaveNewAnswer(Answer answer)
        {
            return _repository.Post(answer);
        }

        public Answer? UpdateAnswer(Answer answer)
        {
            return _repository.Put(answer);
        }

        public bool DeleteAnswer(Answer answer)
        {
            return _repository.Delete(answer);
        }
    }

}

