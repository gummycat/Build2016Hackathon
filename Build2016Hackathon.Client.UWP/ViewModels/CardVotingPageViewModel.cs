using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Build2016Hackathon.Client.UWP.Models;
using System.Collections.ObjectModel;
using Build2016Hackathon.Client.UWP.Services.GameServices;

namespace Build2016Hackathon.Client.UWP.ViewModels
{
    public class CardVotingPageViewModel : ViewModelBase
    {

        public CardVotingPageViewModel()
        {
        }

        public ReadOnlyObservableCollection<Card> CardList
        {
            get
            {
                return GameService.Instance.Cards;
                
            }
        }

        public ReadOnlyObservableCollection<Rating> RatingsList
        {
            get
            {
                return GameService.Instance.Ratings;
            }
        }
        

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), 0);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}

