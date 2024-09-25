using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Person> PeopleList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            PeopleList = new ObservableCollection<Person>
            {
                new Person { ID = 1, Name = "John", Surname = "Doe", PhoneNumber = 123456789, Email = "john@example.com", Adress = "123 Street" },
                new Person { ID = 2, Name = "Jane", Surname = "Smith", PhoneNumber = 987654321, Email = "jane@example.com", Adress = "456 Avenue" },
                new Person { ID = 3, Name = "Robert", Surname = "Brown", PhoneNumber = 321535843, Email = "robert@example.com", Adress = "31 New Street" },
                new Person { ID = 4, Name = "Emily", Surname = "Davis", PhoneNumber = 26742578, Email = "emily@example.com", Adress = "764 Old Stree"},
                new Person { ID = 5, Name = "Michael", Surname = "Wilson", PhoneNumber = 526825643, Email = "michael@example.com", Adress = "3 High Ground"}
            };

            MessagingCenter.Subscribe<PersonDetailsPage, Person>(this, "PersonUpdated", (sender, updatedPerson) =>
            {
                UpdatePersonInList(updatedPerson);
            });

            BindingContext = this;
        }

        private void UpdatePersonInList(Person updatedPerson)
        {
            var person = PeopleList.FirstOrDefault(p => p.ID == updatedPerson.ID);
            if (person != null)
            {
                person.Name = updatedPerson.Name;
                person.Surname = updatedPerson.Surname;
                person.PhoneNumber = updatedPerson.PhoneNumber;
                person.Email = updatedPerson.Email;
                person.Adress = updatedPerson.Adress;
            }
        }

        private async void OnAddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUserPage(PeopleList));
        }
        // Details
        private async void OnViewDetailsClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter is int personId)
            {
                var selectedPerson = PeopleList.FirstOrDefault(p => p.ID == personId);
                if (selectedPerson != null)
                {
                    await Navigation.PushAsync(new PersonDetailsPage(selectedPerson));
                }
            }
        }
        // Edit
        private async void OnEditClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter is int personId)
            {
                var selectedPerson = PeopleList.FirstOrDefault(p => p.ID == personId);
                if (selectedPerson != null)
                {
                    await Navigation.PushAsync(new EditPersonPage(selectedPerson, PeopleList));
                }
            }
        }
        // Delete
        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter is int personId)
            {
                var personToDelete = PeopleList.FirstOrDefault(p => p.ID == personId);
                if (personToDelete != null)
                {
                    PeopleList.Remove(personToDelete);
                }
            }
        }
    }

}
