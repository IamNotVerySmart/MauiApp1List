namespace MauiApp1;

public partial class PersonDetailsPage : ContentPage
{
	public PersonDetailsPage(Person person)
	{
		InitializeComponent();
        BindingContext = person;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}