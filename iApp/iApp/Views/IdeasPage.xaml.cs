using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdeasPage : ContentPage
    {
        public IdeasPage()
        {
            InitializeComponent();
        }

        private async void GoToNewIdeaPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewPage());
        }

        private async void IdeasListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var idea = e.Item as Idea;
            await Navigation.PushAsync(new EditIdeaPage(idea));
        }

        private async void NavigateToSeach_OnClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SearchPage());
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new LoginPage());
        }
    }
}