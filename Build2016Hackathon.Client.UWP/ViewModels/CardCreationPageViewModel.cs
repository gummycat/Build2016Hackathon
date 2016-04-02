using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;

namespace Build2016Hackathon.Client.UWP.ViewModels
{
    public class CardCreationPageViewModel : ViewModelBase
    {
        public CardCreationPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                PlayerName = "Pete";
            }
        }

        string _PlayerName = "";
        public string PlayerName { get { return _PlayerName; } set { Set(ref _PlayerName, value); } }

        string _JoinStatusMessage = "";
        public string JoinStatusMessage { get { return _JoinStatusMessage; } set { Set(ref _JoinStatusMessage, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                PlayerName = suspensionState[nameof(PlayerName)]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(PlayerName)] = PlayerName;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {

            // TODO: connect to server

            // TODO: join with username

            // if join fails, then cancel
            if (!PlayerName.Equals("Pete"))
            {
                args.Cancel = true;
            }
            else
            {
                args.Cancel = false;

                // enable the the Card Creation, Card Voting and Game primary menu items

            }
            
            await Task.CompletedTask;
        }

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), PlayerName);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

