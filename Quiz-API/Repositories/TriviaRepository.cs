using System.Text.Json;
using Quiz_API.Models;

namespace Quiz_API.Repositories;

// Skall hämta information ifrån Trivia API:et
public class TriviaRepository
{
    HttpClient client = new();
    List<TriviaModel> TriviaQuizzes = new();
    
    public async Task<List<TriviaModel>> GetTriviaAsync()
    {
        HttpClient client = new();
        await using Stream stream =
            await client.GetStreamAsync("https://the-trivia-api.com/api/questions?limit=1");
        TriviaQuizzes = await JsonSerializer.DeserializeAsync<List<TriviaModel>>(stream);

        return TriviaQuizzes;
    }
    
    /*
    public async Task<List<TriviaModel>> GetTriviaQuiz()
    {
        try
        {
            var uri = $"https://the-trivia-api.com/api/questions?limit=1";

            using var client = new HttpClient();

            var response = await client.GetAsync(uri);

            var stream =  await response.Content.ReadAsStreamAsync();

            var triviaQuiz = await JsonSerializer.DeserializeAsync<List<TriviaModel>>(stream);
                
            return triviaQuiz;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    } */
    
}