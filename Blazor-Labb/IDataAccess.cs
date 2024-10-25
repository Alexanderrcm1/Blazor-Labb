namespace Blazor_Labb;

public interface IDataAccess
{
	Task<List<User>> GetUsersAsync();
	Task CreateUserListAsync(List<User> users);
}