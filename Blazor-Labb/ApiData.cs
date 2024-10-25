using System.Text.Json;

namespace Blazor_Labb;

public class ApiData : IDataAccess
{
	private string? _jsonString;
	public async Task<List<User>> GetUsersAsync()
	{
		var users = new List<User>();
		await CreateUserListAsync(users);
		return users;
	}

	public async Task CreateUserListAsync(List<User> users)
	{
		_jsonString = await GetJson();
		var apiUsers = JsonSerializer.Deserialize<List<User>>(_jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		if (apiUsers != null) users.AddRange(apiUsers);
	}

	public async Task<string> GetJson()
	{
		string url = "https://jsonplaceholder.typicode.com/users";
		var client = new HttpClient();
		_jsonString = await client.GetStringAsync(url);

		return _jsonString;
	}
}