namespace Blazor_Labb.Components.Pages;

public partial class Users
{
	public void ShowTodos(int buttonId)
	{
		NavigationManager.NavigateTo("todos");
	}

	private List<IUser> users = new List<IUser>();
	private bool showingAll = false;
	private bool nameSortIsDescending = false;
	private bool idSortIsDescending = false;
	private string amountBtn = "Show All";
	private readonly string nameSortBtn = "Sort On Name";
	private readonly string idSortBtn = "Sort On ID";
	private string search = "";
	private int userChooser = 0;

	public async Task ShowApiUsers()
	{
		userChooser = 2;
		await LoadUsers();
	}

	public async Task ShowMyUsers()
	{
		userChooser = 1;
		await LoadUsers();
	}

	public async Task SearchUser()
	{
		if (string.IsNullOrWhiteSpace(search))
		{
			users = await users.ShowAll(userChooser);
		}

		users = await users.SearchForUser(search, userChooser);
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
			users = await users.ShowAll(userChooser);
			amountBtn = "Show 5";
		}
		else
		{
			users = users.ShowFew();
			amountBtn = "Show All";
		}

		StateHasChanged();
	}

	public IUser ChooseUser()
	{
		switch (userChooser)
		{
			case 1:
				return new MyUser();
			case 2:
				return new ApiUser();
			default:
				break;
		}

		return new MyUser();
	}

	public async Task LoadUsers()
	{
		IUser newUser = ChooseUser();
		users = await newUser.GetUsersAsync();
		users = users.ShowFew();
	}
}