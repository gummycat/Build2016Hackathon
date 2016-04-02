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
        }

        string _CardText = "";
        public string CardText { get { return _CardText; } set { Set(ref _CardText, value); } }

        UInt64 _CardRatingId = 0;
        public UInt64 CardRatingId { get { return _CardRatingId; } set { Set(ref _CardRatingId, value); } }

        UInt64 _NumberOfAnswers = 0;
        public UInt64 NumberOfAnswers { get { return _NumberOfAnswers; } set { Set(ref _NumberOfAnswers, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var stuff = await App.gameService.GetRatings();

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
            NavigationService.Navigate(typeof(Views.DetailPage), CardText);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

