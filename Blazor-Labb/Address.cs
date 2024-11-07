using System.ComponentModel.DataAnnotations;

namespace Blazor_Labb;

public class Address
{
	[RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Street contains invalid characters")]
	public string? Street { get; set; }

	[RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "City contains invalid characters")]
	public string? City { get; set; }

	[RegularExpression(@"^\d+(\s\d+)*$", ErrorMessage = "Zipcode contains invalid characters")]
	public string? Zipcode { get; set; }

}