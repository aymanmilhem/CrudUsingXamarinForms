using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudUsingXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();


        }

        private async void  Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCompanyPage());
        }

        private async void Get_Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllCompaniesPage());
        }

        private async void Edit_Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompnayPage());
        }

        private async void Delete_Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompnayPage());
        }
    }
}