using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using iApp.Helpers;
using iApp.Models;
using iApp.Services;
using Xamarin.Forms;

namespace iApp.ViewModels
{
    public class AddNewIdeasViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var idea = new Idea
                    {
                        Title = Title,
                        Description = Description,
                        Category = Category
                    };
                   var isSuccess =  await _apiServices.PostIdeaAsync(idea, Settings.AccessToken);

                   if (isSuccess)
                   {
                       Message = "New Idea Added";
                   }
                   else
                   {
                       Message = "Error!";
                   }
                });
            }
        }
    }
}
