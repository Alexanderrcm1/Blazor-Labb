namespace Blazor_Labb.Components.Pages;

public partial class Home
{
	private string _title = "";
	private string _name = "";
	private readonly string[] _titleArray = ["B", "L", "A", "Z", "O", "R", " ", "L", "A", "B", "B"];
	private bool _showBtn = true;

	public async Task BtnClick()
	{
		if (_title == "")
		{
			_showBtn = false;
			foreach (var t in _titleArray)
			{
				_title += t;
				StateHasChanged();
				await Task.Delay(200);
			}

			await Task.Delay(1000);
			_name = "Alexander Carlsson Musa";
		}
	}
}