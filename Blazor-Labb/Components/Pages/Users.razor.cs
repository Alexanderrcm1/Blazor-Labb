using System.Text.Json;

namespace Blazor_Labb.Components.Pages;

public partial class Users
{
	private List<User> users = new List<User>();
	private bool showingAll = false;
	private bool nameSortIsDescending = false;
	private bool idSortIsDescending = false;
	private string amountBtn = "Show All";
	private readonly string nameSortBtn = "Sort On Name";
	private readonly string idSortBtn = "Sort On ID";
	private string search = "";
	private int dataChooser = 0;

	public async Task ShowApiUsers()
	{
		dataChooser = 2;
		await LoadData();
	}

	public async Task ShowMyUsers()
	{
		dataChooser = 1;
		await LoadData();
	}

	public async Task SearchUser()
	{
		if (string.IsNullOrWhiteSpace(search))
		{
			users = await users.ShowAll(dataChooser);
		}

		users = await users.SearchForUser(search, dataChooser);
		search = "";
		showingAll = false;
		amountBtn = "Show All";
		StateHasChanged();
	}

	public void IdSort()
	{
		idSortIsDescending = !idSortIsDescending;

		if (idSortIsDescending)
		{
			users = users.SortOnId();
		}
		else
		{
			users = users.SortOnIdDesc();
		}

		StateHasChanged();
	}

	public void NameSort()
	{
		nameSortIsDescending = !nameSortIsDescending;

		if (nameSortIsDescending)
		{
			users = users.SortOnName();
		}
		else
		{
			users = users.SortOnNameDesc();
		}

		StateHasChanged();
	}

	public async Task ShowAmount()
	{
		showingAll = !showingAll;

		if (showingAll)
		{
			users = await users.ShowAll(dataChooser);
			amountBtn = "Show 5";
		}
		else
		{
			users = users.ShowFew();
			amountBtn = "Show All";
		}

		StateHasChanged();
	}

	public IDataAccess ChooseData()
	{
		switch (dataChooser)
		{
			case 1:
				return new DummyData();
			case 2:
				return new ApiData();
			default:
				break;
		}

		return new DummyData();
	}

	public async Task LoadData()
	{
		IDataAccess data = ChooseData();
		await Task.Delay(1500);
		users = await data.GetUsersAsync();
		users = users.ShowFew();
	}
}