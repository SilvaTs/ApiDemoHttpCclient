using HttpClientFactoryProject.Configuration;
using HttpClientFactoryProject.Models;

namespace HttpClientFactoryProject.Services
{
    public class TodoService : ITodoService
    {
        private readonly IApiConfig _apiConfig;
        private readonly HttpClient _httpClient;

        public TodoService
        (
            IApiConfig apiConfig,
            HttpClient httpClient
        )
        {
            _apiConfig = apiConfig;
            _httpClient = httpClient;
        }

        public async Task<TodoModel> GetTodo(int id)
        {
            return await _httpClient.GetFromJsonAsync<TodoModel>(
            $"{_apiConfig.BaseUrl}todos/{id}");
        }
    }
}