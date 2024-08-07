using System.Data.Common;
using System.Net.Http.Json;
using System.Text.Json;

namespace blazor_app_demo;

public class CategoryService : ICategoryService
{
    private readonly HttpClient client;

    private readonly JsonSerializerOptions options;

    public CategoryService(HttpClient _client, JsonSerializerOptions _options)
    {
        client = _client;
        options = _options;
    }

    public async Task<List<Category>?> Get()
    {
        var response = await client.GetAsync("categories");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        return JsonSerializer.Deserialize<List<Category>>(content, options);
    }
}

public interface ICategoryService
{
    Task<List<Category>?> Get();
}