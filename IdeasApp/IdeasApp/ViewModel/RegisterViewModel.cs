using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using IdeasApp.Services;
using Xamarin.Forms;

namespace IdeasApp.ViewModel
{
    public class RegisterViewModel
    {
         ApiServices _apiServices = new ApiServices();
        public string Email { get; set; } 
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                   var isSuccess = await _apiServices.RegisterAsync(Email, Password, ComfirmPassword);

                   if(isSuccess)
                   {
                       Message = "User Registered!";
                   }
                   else
                   {
                       Message = "Retry Later";
                   }
                });
            }
        }
    }
}
