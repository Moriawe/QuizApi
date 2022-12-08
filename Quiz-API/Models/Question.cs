using System;
namespace Quiz_API.Models
{
	public class Question
	{
        public string Language { get; set; } = "svenska";
        public string Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; } // music, history, film

        public Question(string language, string text, string category)
		{
        //  this.Id = Guid.NewGuid(); // Let database do this (but sqlite generates Id:s as int:s...)
            this.Language = language;
            this.Text = text;
            this.Category = category;

        }
	}
}

