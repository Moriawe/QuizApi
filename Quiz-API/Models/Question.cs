using System;
namespace Quiz_API.Models
{
	public class Question
	{
		public string Id { get; set; }
		public string Text { get; set; }
        public Category Category { get; set; } // music, history, film
		
        //public virtual IList<Answer> Answers { get; set; }

        public Question(string text, Category category)
		{
        //  this.Id = Guid.NewGuid(); // Let database do this (but sqlite generates Id:s as int:s...)
			this.Text = text;
            this.Category = category;

        }
	}
}

