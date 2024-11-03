using System.Text.Json;

namespace Blazor_Labb;

public class TodoService
{
	public async Task<List<Todo>> GetTodoListAsync()
	{
		string url = "https://jsonplaceholder.typicode.com/todos";
		HttpClient client = new HttpClient();
		string jsonString = await client.GetStringAsync(url);

		return JsonSerializer.Deserialize<List<Todo>>(jsonString);
	}
}