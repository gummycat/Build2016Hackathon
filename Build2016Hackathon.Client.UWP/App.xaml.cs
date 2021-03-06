using Windows.UI.Xaml;
using System.Threading.Tasks;
using Build2016Hackathon.Client.UWP.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using System;
using System.Linq;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Microsoft.WindowsAzure.MobileServices;
using Build2016Hackathon.Client.UWP.Services.GameServices;

namespace Build2016Hackathon.Client.UWP
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    sealed partial class App : Template10.Common.BootStrapper
    {
        //MessageWebSocket mws = new MessageWebSocket();
        public static MobileServiceClient client;
        public static GameService gameService;

        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);
            client = new MobileServiceClient("https://cardvana.azure-mobile.net", "jVRmaPXnyLFZnvofbYUkyjRuUDloXI51");
            gameService = GameService.Instance;

            #region App settings

            var _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            if (Window.Current.Content as ModalDialog == null)
            {
                // create a new frame 
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
                // create modal root
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = new Views.Shell(nav),
                    ModalContent = new Views.Busy(),
                };
            }
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here

            NavigationService.Navigate(typeof(Views.MainPage));
            await Task.CompletedTask;
        }
    }
}

