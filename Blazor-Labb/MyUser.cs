namespace Blazor_Labb;

public class MyUser : IUser
{
	public string Name { get; set; }
	public string Email { get; set; }
	public int Id { get; set; }
	public Address Address { get; set; }
	public Company Company { get; set; }

	public MyUser()
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
		await CreateUserList(users);
		return users;
	}

	public async Task CreateUserList(List<IUser> users)
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

			var user = new MyUser
			{
				Name = names[i],
				Id = i + 1,
				Email = $"{names[i]}{i + 1}@{companies[index]}.com",
				Address = new Address() { City = cities[index], Street = streets[index], Zipcode = zipcodes[index] },
				Company = new Company() { Name = companies[index], Catchphrase = catchphrases[index] },
			};
			users.Add(user);
		}
		await Task.Delay(1500);

	}
}