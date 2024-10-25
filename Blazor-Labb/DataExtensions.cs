using Blazor_Labb.Components.Pages;
using static Blazor_Labb.Components.Pages.Users;

namespace Blazor_Labb;

public static class DataExtensions
{
	public static async Task<List<User>> SearchForUser(this List<User> users, string search, int userChooser)
	{
		users = await users.ShowAll(userChooser);
		if (string.IsNullOrWhiteSpace(search))
		{
			return users;
		}

		IEnumerable<User> query =
			from user in users
			where user.Name.ToLower().Contains(search.ToLower())
			select user;

		return query.ToList();
	}
	public static List<User> SortOnId(this List<User> users)
	{
		IEnumerable<User> query =
			from user in users
			orderby user.Id
			select user;

		return query.ToList();
	}

	public static List<User> SortOnIdDesc(this List<User> users)
	{
		IEnumerable<User> query =
			from user in users
			orderby user.Id descending 
			select user;

		return query.ToList();
	}
	public static List<User> SortOnName(this List<User> users)
	{
		IEnumerable<User> query =
			from user in users
			orderby user.Name[0]
			select user;

		return query.ToList();
	}

	public static List<User> SortOnNameDesc(this List<User> users)
	{
		IEnumerable<User> query =
			from user in users
			orderby user.Name[0] descending 
			select user;

		return query.ToList();
	}

	public static List<User> ShowFew(this List<User> users)
	{
		var userList = new List<User>();

		for (int i = 0; i < 5; i++)
		{
			userList.Add(users[i]);
		}

		return userList;
	}

	public static async Task<List<User>> ShowAll(this List<User> users, int userChooser)
	{
		IDataAccess data;

		if (userChooser == 1)
		{
			data = new DummyData();
			users = await data.GetUsersAsync();
		}
		else if (userChooser == 2)
		{
			data = new ApiData();
			users = await data.GetUsersAsync();
		}
		return users;
	}
}