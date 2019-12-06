using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudUsingXamarin.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudUsingXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCompnayPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _namEntry;
        private Entry _addressEntry;
        private Button _button;

        Company _company = new Company();

        string _dBPath =
            Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public EditCompnayPage()
        {

            this.Title = "Edit Company";

            var db = new SQLiteConnection(_dBPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Keyboard = Keyboard.Text;
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _namEntry = new Entry();
            _namEntry.Keyboard = Keyboard.Text;
            _namEntry.Placeholder = "Company Name";
            stackLayout.Children.Add(_namEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(_addressEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += update_Button_Clicked;
            stackLayout.Children.Add(_button);

           


            Content = stackLayout;


        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = e.SelectedItem as Company;
            _idEntry.Text = _company.Id.ToString();
            _namEntry.Text = _company.Name.ToString().ToLower();
            _addressEntry.Text = _company.Address.ToString().ToUpper() + " :-P";
        }

        private async void update_Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dBPath);
            Company company = new Company
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _namEntry.Text,
                Address = _addressEntry.Text
            };
            db.Update(company);
            await Navigation.PopAsync();
        }
    }
}