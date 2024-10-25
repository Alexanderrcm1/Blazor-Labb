namespace Blazor_Labb;

public class User
{
	public string Name { get; set; }
	public string Email { get; set; }
	public int Id { get; set; }
	public Address Address { get; set; }
	public Company Company { get; set; }


	public User()
	{
		Address = new Address();
		Company = new Company();
		Name = "";
		Email = "";
		Id = 0;
	}
}