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
    public partial class DeleteCompnayPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Company _company = new Company();

        string _dBPath =
            Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteCompnayPage()
        {
            this.Title = "Delete Company";

            var db = new SQLiteConnection(_dBPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += delete_Button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _company = e.SelectedItem as Company;
        }

        private async void delete_Button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dBPath);

            db.Table<Company>().Delete(x => x.Id == _company.Id);

            await Navigation.PopAsync();
        }
    }
}