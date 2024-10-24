using System.Text.Json;

namespace Blazor_Labb;

public class ApiUser : IUser
{
	private string? _jsonString;

	public string Name { get; set; }
	public string Email { get; set; }
	public int Id { get; set; }
	public Address Address { get; set; }
	public Company Company { get; set; }


	public ApiUser()
	{
		Address = new Address();
		Company = new Company();
		Name = "";
		Email = "";
		Id = 0;
	}

	public async Task<List<IUser>> GetUsersAsync()
	{
		var users = new List<IUser>();
		await CreateUserListAsync(users);
		return users;
	}

	public async Task CreateUserListAsync(List<IUser> users)
	{
		_jsonString = await GetJson();
		var apiUsers = JsonSerializer.Deserialize<List<ApiUser>>(_jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		await Task.Delay(1500);
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