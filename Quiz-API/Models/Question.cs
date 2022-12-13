using System;
namespace Quiz_API.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; } // music, history, film

        //public virtual IList<Answer> Answers { get; set; }

        public Question(string text, string category)
        {
            this.Id = Guid.NewGuid(); // Let database do this (but sqlite generates Id:s as int:s...)
            this.Text = text;
            this.Category = category;

        }
    }
}

