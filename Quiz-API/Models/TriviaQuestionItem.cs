namespace Quiz_API.Models;

public class TriviaQuestionItem
{
    public string Category { get; set; }
    public string Id { get; set; }
    public string CorrectAnswer { get; set; }
    public string[] IncorrectAnswer { get; set; }
    public string Question { get; set; }
    //public string[] Tags { get; set; }
    //public string Type { get; set; }
    public string Difficulty { get; set; }
    //public string regions { get; set; }
    //public bool IsNiche { get; set; }
    
}