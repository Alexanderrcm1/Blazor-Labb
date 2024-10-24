using Blazor_Labb.Components.Pages;

namespace Blazor_Labb;

public interface IUser
{
	public string Name { get; set; }
	public string Email { get; set; }
	public int Id { get; set; }
	public Address Address { get; set; }
	public Company Company { get; set; }

	Task<List<IUser>> GetUsersAsync();
}