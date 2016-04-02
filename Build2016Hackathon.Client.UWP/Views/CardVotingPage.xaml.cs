using System;
using Build2016Hackathon.Client.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace Build2016Hackathon.Client.UWP.Views
{
    public sealed partial class CardVotingPage : Page
    {
        public CardVotingPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
    }
}
