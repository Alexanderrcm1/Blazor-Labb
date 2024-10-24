namespace Blazor_Labb.Components.Pages;

public partial class Home
{
	private string title = "";
	private string name = "";
	private string[] titleArray = ["B", "L", "A", "Z", "O", "R", " ", "L", "A", "B", "B"];
	private bool showBtn = true;

	public async Task BtnClick()
	{
		if (title == "")
		{
			showBtn = false;
			foreach (var s in titleArray)
			{
				title += s;
				StateHasChanged();
				await Task.Delay(200);
			}

			await Task.Delay(1000);
			name = "Alexander Carlsson Musa";
		}
	}
}