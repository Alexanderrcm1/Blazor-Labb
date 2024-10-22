using Blazor_Labb.Components.Pages;
using static Blazor_Labb.Components.Pages.Users;

namespace Blazor_Labb;

public static class UserExtensions
{
	public static async Task<List<Users.IUser>> SearchForUser(this List<Users.IUser> users, string search, int userChooser)
	{
		users = await users.ShowAll(userChooser);
		if (string.IsNullOrWhiteSpace(search))
		{
			return users;
		}

		IEnumerable<Users.IUser> query =
			from user in users
			where user.Name.ToLower().Contains(search.ToLower())
			select user;

		return query.ToList();
	}
	public static List<Users.IUser> SortOnId(this List<Users.IUser> users)
	{
		IEnumerable<Users.IUser> query =
			from user in users
			orderby user.Id
			select user;

		return query.ToList();
	}

	public static List<Users.IUser> SortOnIdDesc(this List<Users.IUser> users)
	{
		IEnumerable<Users.IUser> query =
			from user in users
			orderby user.Id descending 
			select user;

		return query.ToList();
	}
	public static List<Users.IUser> SortOnName(this List<Users.IUser> users)
	{
		IEnumerable<Users.IUser> query =
			from user in users
			orderby user.Name[0]
			select user;

		return query.ToList();
	}

	public static List<Users.IUser> SortOnNameDesc(this List<Users.IUser> users)
	{
		IEnumerable<Users.IUser> query =
			from user in users
			orderby user.Name[0] descending 
			select user;

		return query.ToList();
	}

	public static List<Users.IUser> ShowFew(this List<Users.IUser> users)
	{
		List<Users.IUser> userList = new List<Users.IUser>();

		for (int i = 0; i < 5; i++)
		{
			userList.Add(users[i]);
		}

		return userList;
	}

	public static async Task<List<Users.IUser>> ShowAll(this List<Users.IUser> users, int userChooser)
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