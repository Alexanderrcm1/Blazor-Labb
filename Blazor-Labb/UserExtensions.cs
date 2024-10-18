using Blazor_Labb.Components.Pages;
using static Blazor_Labb.Components.Pages.Users;

namespace Blazor_Labb;

public static class UserExtensions
{
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

	public static async Task<List<Users.IUser>> ShowAll(this List<Users.IUser> users)
	{
		IUser newUser = new MyUser();
		users = await newUser.GetUsersAsync();
		return users;
	}
}