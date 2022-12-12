namespace Quiz_API.Models;

// Datastrukturen som tas emot från Trivia API:et
public class TriviaModel
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

    public TriviaModel(string category, string id, string correctAnswer, string[] incorrectAnswer, string question, string difficulty)
    {
        Category = category;
        Id = id;
        CorrectAnswer = correctAnswer;
        IncorrectAnswer = incorrectAnswer;
        Question = question;
        Difficulty = difficulty;
    }
    
}
/*
public class MockQuestions
{
    private TriviaQuestionItem[] Questions = new TriviaQuestionItem[5];
    
    TriviaQuestionItem question1 = new TriviaQuestionItem("Science", "6242caf8d543524f1b19c8ff", "A sloth", ["A rag", "A paddling", "A sedge"], "What is the word for a group of bears?", "hard");
    TriviaQuestionItem question2 = new TriviaQuestionItem("Geography", "623385d662eaad73716a8c97", "Mount Whitney", ["Mount Rushmore", "Mount Elbert", "Mount Rainier"], "What's the highest mountain in the 48 contiguous U.S. states?",  "medium")
    TriviaQuestionItem question3 = new TriviaQuestionItem("Geography", "625e9ef9796f721e95543f7a", "Blue", ["Yellow", "Green", "Orange"], "Which of these colors would you find on the flag of Israel?", "medium");
    TriviaQuestionItem question4 = new TriviaQuestionItem("Geography", "622a1c357cc59eab6f94fe3c", "Key West", ["Key North", "East Key", "South Key"], "The southernmost point in the 48 mainland American states?", "medium");
    TriviaQuestionItem question5 = new TriviaQuestionItem("Geography", "623742f4cb85f7ce9e949e02", "Hanoi", ["Ho Chi Minh City", "Da Nang", "Hue"], "What is the capital city of Vietnam?", "medium");
    TriviaQuestionItem question6 = new TriviaQuestionItem("General Knowledge", "622a1c3a7cc59eab6f9510ac", "Donkey", ["Sheep", "Goat", "Horse"], "Of What Is A Jenny The Female?", "medium");
    TriviaQuestionItem question7 = new TriviaQuestionItem("General Knowledge", "622a1c3a7cc59eab6f951082", "Libra", ["Scorpio", "Gemini", "Aries"], "What constellation is represented by scales?", "medium");
    TriviaQuestionItem question8 = new TriviaQuestionItem("General Knowledge", "6239f82ea72e7a347ac879d4", "Romeo", ["Rwanda", "Roar", "Rowboat"], "What word is used in the NATO Phonetic Alphabet for the letter R?", "medium");
    TriviaQuestionItem question9 = new TriviaQuestionItem("General Knowledge", "622a1c357cc59eab6f94fc7c", "Grommet", ["Winklepicker", "Curmudgeon", "Cattywampus"], "Which word is defined as 'an eyelet of firm material to strengthen or protect an opening or to insulate or protect something passed through it'?", "medium");
    TriviaQuestionItem question10 = new TriviaQuestionItem("General Knowledge", "622a1c357cc59eab6f94fc6c", "Macrosmatic", {"Nudiustertian", "Conjubilant", "Gubbins"}, "Which word is defined as 'having a good sense of smell'?", "medium");
        
    TriviaQuestionItem[] = {};    
}
*/