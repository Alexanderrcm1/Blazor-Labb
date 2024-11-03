using System.Text.Json;

namespace Blazor_Labb;

public class Todo
{
	public int userId { get; set; }
	public int id { get; set; }
	public string title { get; set; }
	public bool completed { get; set; }

	public Todo()
	{
		
	}
}