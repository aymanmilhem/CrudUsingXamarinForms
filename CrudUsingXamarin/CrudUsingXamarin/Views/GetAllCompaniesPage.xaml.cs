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
    public partial class GetAllCompaniesPage : ContentPage
    {
        private ListView _listView;
        string _dBPath =
            Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public GetAllCompaniesPage()
        {
            //InitializeComponent();

            this.Title = "Companies";

            var db = new SQLiteConnection(_dBPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}