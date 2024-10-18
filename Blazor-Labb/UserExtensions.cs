using Blazor_Labb.Components.Pages;

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
}