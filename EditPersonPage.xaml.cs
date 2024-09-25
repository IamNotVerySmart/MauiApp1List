using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class EditPersonPage : ContentPage
{
    private Person _person;
    private ObservableCollection<Person> _peopleList;

    public EditPersonPage(Person person, ObservableCollection<Person> peopleList)
    {
        InitializeComponent();
        _person = person;
        _peopleList = peopleList;
        BindingContext = _person;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var updatedPerson = (Person)BindingContext;
        MessagingCenter.Send(this, "PersonUpdated", updatedPerson);
        await Navigation.PopAsync();
    }
}