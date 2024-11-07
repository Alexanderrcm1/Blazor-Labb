using System.ComponentModel.DataAnnotations;

namespace Blazor_Labb;

public class Company
{	
		[Required]
	 	public string? Name { get; set; }

	    [Required]
		public string? Catchphrase { get; set; }
}