using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //BindingContext = new LoginViewModel(Navigation);
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        { 
            await Navigation.PushAsync(new IdeasPage());
        }
    }
}