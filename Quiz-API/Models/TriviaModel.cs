namespace Quiz_API.Models;
using System.Text.Json.Serialization;

// Datastrukturen som tas emot från Trivia API:et
public record class TriviaModel(
    [property: JsonPropertyName("category")] string Category,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("correctAnswer")] string CorrectAnswer,
    [property: JsonPropertyName("incorrectAnswers")] List<string> IncorrectAnswers,
    [property: JsonPropertyName("question")] string Question,
    [property: JsonPropertyName("tags")] List<object> Tags,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("difficulty")] string Difficulty,
    [property: JsonPropertyName("regions")] List<object> Regions,
    [property: JsonPropertyName("isNiche")] bool IsNiche
    );
