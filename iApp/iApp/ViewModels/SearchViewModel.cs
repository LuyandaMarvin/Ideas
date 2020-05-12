using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using iApp.Helpers;
using iApp.Models;
using iApp.Services;
using Xamarin.Forms;

namespace iApp.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<Idea> _ideas;
        public string Keyword { get; set; }

        public List<Idea> Ideas
        {
            get => _ideas;
            set
            {
                _ideas = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Ideas =await _apiServices.SearchIdeasAsync(Keyword, Settings.AccessToken);

                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
