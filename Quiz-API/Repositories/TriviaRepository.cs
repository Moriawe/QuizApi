using System.Text.Json;
using Quiz_API.Models;

namespace Quiz_API.Repositories;

// Skall hämta information ifrån Trivia API:et
public class TriviaRepository
{
    HttpClient _client = new();
    
    public async Task<List<TriviaModel>> GetTriviaAsync()
    {
        var uri = $"https://the-trivia-api.com/api/questions?limit=1";
        List<TriviaModel> triviaQuizzes = new();
        
        // Skillnad på stream, get StreamAsync och just GetAsync
        //await using Stream stream = await _client.GetStreamAsync(uri);
        var response = await _client.GetAsync(uri);
        var stream = await response.Content.ReadAsStreamAsync();
        
        triviaQuizzes = await JsonSerializer.DeserializeAsync<List<TriviaModel>>(stream);
        Console.WriteLine(triviaQuizzes);
        return triviaQuizzes;
    }
    
}