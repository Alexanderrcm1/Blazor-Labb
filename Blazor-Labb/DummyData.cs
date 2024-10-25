namespace Blazor_Labb;

public class DummyData : IDataAccess
{
	public async Task<List<User>> GetUsersAsync()
	{
		var users = new List<User>();
		await CreateUserListAsync(users);
		return users;
	}

	public Task CreateUserListAsync(List<User> users)
	{
		string[] names =
		[
			"Alexander Hansson", "Emma Carlsson", "Olivia Jonsson", "Elias Svensson", "Noah Eriksson", "Ava Avasson", "Jonas Jonasson", "Bengt Bengtsson", "Charlie Charlsson", "Elsa Elsson", "Maja Majsson", "Gustav Gusson", "Karl Karlsson", "Erika Eriksson", "Hugo Hugsson"
		];

		string[] cities = ["Stockholm", "Göteborg", "Malmö"];
		string[] streets = ["Sveavägen", "Avenyn", "Kungsgatan"];
		string[] zipcodes = ["143 23", "103 43", "195 89"];
		string[] companies = ["Apple", "Microsoft", "Tesla"];
		string[] value = ["Think Different", "Empowering us all", "Accelerating the world's transition to sustainable energy"];
		string[] catchphrases = value;

		for (int i = 0; i < 15; i++)
		{

			int index = i % cities.Length;

			var user = new User
			{
				Name = names[i],
				Id = i + 1,
				Email = $"{names[i]}{i + 1}@{companies[index]}.com",
				Address = new Address() { City = cities[index], Street = streets[index], Zipcode = zipcodes[index] },
				Company = new Company() { Name = companies[index], Catchphrase = catchphrases[index] },
			};
			users.Add(user);
		}

		return Task.CompletedTask;
	}
}