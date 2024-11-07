using System.ComponentModel.DataAnnotations;

namespace Blazor_Labb;

public class Address
{
	[Required]
	[RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "Street contains invalid characters")]
	public string? Street { get; set; }

	[Required]
	[RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "City contains invalid characters")]
	public string? City { get; set; }

	[Required]
	[RegularExpression(@"^\d+(\s\d+)*$", ErrorMessage = "Zipcode contains invalid characters")]
	public string? Zipcode { get; set; }

}