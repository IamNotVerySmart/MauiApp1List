using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class AddUserPage : ContentPage
{
    private ObservableCollection<Person> _peopleList;

    public AddUserPage(ObservableCollection<Person> peopleList)
    {
        InitializeComponent();
        _peopleList = peopleList;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(nameEntry.Text))
        {
            int newId = _peopleList.Count + 1;
            _peopleList.Add(new Person { ID = newId, Name = nameEntry.Text });

            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please enter a valid name.", "OK");
        }
    }
}