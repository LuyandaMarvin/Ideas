using System;
using iApp.Helpers;
using iApp.ViewModels;
using iApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
            // MainPage = new NavigationPage(new RegisterPage());
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                if (DateTime.Now.AddHours(1) > Settings.AccessTokenExpiration)
                {
                    var vm = new LoginViewModel();
                    vm.LoginCommand.Execute(null);
                }
                MainPage = new NavigationPage(new IdeasPage());
            }
            else if(!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
