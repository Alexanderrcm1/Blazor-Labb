using System.ComponentModel.DataAnnotations;

namespace Blazor_Labb.Components.Pages;

public partial class NewUser
{
	private readonly User _user = new();
	private string _title = "Add a new user";
	private bool _formNotDone = true;

	public class User
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z]+(-[a-zA-Z]+)*$", ErrorMessage = "First name contains invalid characters")]
		public string? FirstName { get; set; }

		[Required]
		[RegularExpression(@"^[a-zA-Z]+(-[a-zA-Z]+)*$", ErrorMessage = "Last name contains invalid characters")]
		public string? LastName { get; set; }

		[Required]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]{3,}@[a-zA-Z0-9.-]{3,}\.[a-zA-Z]{2,3}$",
			ErrorMessage = "Incorrect Email.")]
		public string? Email { get; set; }

		[Range(12, 99)] public int Age { get; set; }
	}

	public void AddUser()
	{
		_formNotDone = false;
		_title = "User Added!";
	}

	public void AddNewUser()
	{
		_formNotDone = true;
		_title = "Add a new user";
		_user.FirstName = "";
		_user.LastName = "";
		_user.Email = "";
		_user.Age = 0;
	}
}