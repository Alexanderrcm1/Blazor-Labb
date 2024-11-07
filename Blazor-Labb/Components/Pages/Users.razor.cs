using System.Text.Json;

namespace Blazor_Labb.Components.Pages;

public partial class Users
{
	private List<User> _users = new ();
	private bool _showingAll = false;
	private bool _nameSortIsDescending = false;
	private bool _idSortIsDescending = false;
	private string _amountBtn = "Show All";
	private readonly string _nameSortBtn = "Sort On Name";
	private readonly string _idSortBtn = "Sort On ID";
	private string _search = "";
	private int _dataChooser = 0;
	private bool _loading = true;

	public async Task ShowApiUsers()
	{
		_dataChooser = 2;
		await LoadData();
	}

	public async Task ShowMyUsers()
	{
		_dataChooser = 1;
		await LoadData();
	}

	public async Task SearchUser()
	{
		if (string.IsNullOrWhiteSpace(_search))
		{
			_users = await _users.ShowAll(_dataChooser);
		}

		_users = await _users.SearchForUser(_search, _dataChooser);
		_search = "";
		_showingAll = false;
		_amountBtn = "Show All";
		StateHasChanged();
	}

	public void IdSort()
	{
		_idSortIsDescending = !_idSortIsDescending;

		if (_idSortIsDescending)
		{
			_users = _users.SortOnId();
		}
		else
		{
			_users = _users.SortOnIdDesc();
		}

		StateHasChanged();
	}

	public void NameSort()
	{
		_nameSortIsDescending = !_nameSortIsDescending;

		if (_nameSortIsDescending)
		{
			_users = _users.SortOnName();
		}
		else
		{
			_users = _users.SortOnNameDesc();
		}

		StateHasChanged();
	}

	public async Task ShowAmount()
	{
		_showingAll = !_showingAll;

		if (_showingAll)
		{
			_users = await _users.ShowAll(_dataChooser);
			_amountBtn = "Show 5";
		}
		else
		{
			_users = _users.ShowFew();
			_amountBtn = "Show All";
		}

		StateHasChanged();
	}

	public IDataAccess ChooseData()
	{
		switch (_dataChooser)
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
		_users = await data.GetUsersAsync();
		_users = _users.ShowFew();
		await Task.Delay(1500);
		_loading = false;
	}
}