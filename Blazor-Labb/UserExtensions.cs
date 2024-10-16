using Blazor_Labb.Components.Pages;

namespace Blazor_Labb;

public static class UserExtensions
{
	public static List<Users.User> SortOnName(this List<Users.User> users)
	{
		IEnumerable<Users.User> query =
			from user in users
			orderby user.userInfo.Name[0]
			select user;

		return query.ToList();
	}
}