using System.Text.Json;
using Quiz_API.Models;

namespace Quiz_API.Repositories;

// Skall hämta information ifrån Trivia API:et
public class TriviaRepository
{
    
    public async Task<List<TriviaModel>> GetTriviaQuiz()
    {
        try
        {
            var uri = $"https://the-trivia-api.com/api/questions?limit=1";

            using var client = new HttpClient();

            var response = await client.GetAsync(uri);

            var stream =  await response.Content.ReadAsStreamAsync();

            var TriviaQuiz = await JsonSerializer.DeserializeAsync<List<TriviaModel>>(stream);
                
            return TriviaQuiz;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
}