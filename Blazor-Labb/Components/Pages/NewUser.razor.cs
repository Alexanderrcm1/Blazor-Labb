using System.ComponentModel.DataAnnotations;

namespace Blazor_Labb.Components.Pages;

public partial class NewUser
{
	private readonly User _user = new();
	private string _title = "Add a new user";
	private bool _formNotDone = true;

	public void AddUser()
	{
		_formNotDone = false;
		_title = "User Added!";
	}

	public void AddNewUser()
	{
		_formNotDone = true;
		_title = "Add a new user";
		_user.Id = 0;
		_user.Name = "";
		_user.Email = "";
		_user.Address.Street = "";
		_user.Address.City = "";
		_user.Address.Zipcode = "";
		_user.Company.Name = "";
		_user.Company.Catchphrase = "";
	}
}