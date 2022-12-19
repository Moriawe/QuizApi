using System;
namespace Quiz_API.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string TriviaId { get; set; }
        public string Text { get; set; }
        public string Category { get; set; } // music, history, film // Maybe Category (table and class).


        public Question(string text, string triviaId, string category) // Maybe Category category (table and class).
        {
            this.Id = Guid.NewGuid(); // Let database do this (but sqlite generates Id:s as int:s...)
            this.TriviaId = triviaId;
            this.Text = text;
            this.Category = category;

        }
    }
}

