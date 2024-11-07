using System.ComponentModel.DataAnnotations;

namespace Blazor_Labb;

public class User
{
	[Required]
	[RegularExpression(@"^[a-zA-Z]+([-\s][a-zA-Z]+)*$", ErrorMessage = "Name contains invalid characters")]
	public string Name { get; set; }
	[Required]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]{3,}@[a-zA-Z0-9.-]{3,}\.[a-zA-Z]{2,3}$", ErrorMessage = "Incorrect Email.")]
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