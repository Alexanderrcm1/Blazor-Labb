using Blazor_Labb.Components.Pages;
using static Blazor_Labb.Components.Pages.Users;

namespace Blazor_Labb;

public static class UserExtensions
{
	public static async Task<List<IUser>> SearchForUser(this List<IUser> users, string search, int userChooser)
	{
		users = await users.ShowAll(userChooser);
		if (string.IsNullOrWhiteSpace(search))
		{
			return users;
		}

		IEnumerable<IUser> query =
			from user in users
			where user.Name.ToLower().Contains(search.ToLower())
			select user;

		return query.ToList();
	}
	public static List<IUser> SortOnId(this List<IUser> users)
	{
		IEnumerable<IUser> query =
			from user in users
			orderby user.Id
			select user;

		return query.ToList();
	}

	public static List<IUser> SortOnIdDesc(this List<IUser> users)
	{
		IEnumerable<IUser> query =
			from user in users
			orderby user.Id descending 
			select user;

		return query.ToList();
	}
	public static List<IUser> SortOnName(this List<IUser> users)
	{
		IEnumerable<IUser> query =
			from user in users
			orderby user.Name[0]
			select user;

		return query.ToList();
	}

	public static List<IUser> SortOnNameDesc(this List<IUser> users)
	{
		IEnumerable<IUser> query =
			from user in users
			orderby user.Name[0] descending 
			select user;

		return query.ToList();
	}

	public static List<IUser> ShowFew(this List<IUser> users)
	{
		var userList = new List<IUser>();

		for (int i = 0; i < 5; i++)
		{
			userList.Add(users[i]);
		}

		return userList;
	}

	public static async Task<List<IUser>> ShowAll(this List<IUser> users, int userChooser)
	{
		IUser newUser;

		if (userChooser == 1)
		{
			newUser = new MyUser();
			users = await newUser.GetUsersAsync();
		}
		else if (userChooser == 2)
		{
			newUser = new ApiUser();
			users = await newUser.GetUsersAsync();
		}
		return users;
	}
}