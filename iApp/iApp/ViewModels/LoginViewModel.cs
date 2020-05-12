using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using iApp.Helpers;
using iApp.Services;
using iApp.Views;
using Xamarin.Forms;

namespace iApp.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                   var accesstoken = await _apiServices.LoginAsync(Username, Password);
                    if (accesstoken == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("ERROR", "Incorrect Username or Password!", "Ok");
                    }
                    else
                    {
                        App.Current.MainPage = new NavigationPage(new IdeasPage());
                    }
                    
                    Settings.AccessToken = accesstoken;
                });
            }
        }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
