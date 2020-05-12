using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iApp.Models;
using iApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditIdeaPage : ContentPage
    {
        public EditIdeaPage(Idea idea)
        {
            var editIdeaViewModel = new EditIdeaViewModel();
            editIdeaViewModel.Idea = idea;

            BindingContext = editIdeaViewModel;

            InitializeComponent();

            //var editIdeaViewModel = BindingContext as EditIdeaViewModel;

            //editIdeaViewModel.Idea = idea;
        }
    }
}