using System;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;

namespace Build2016Hackathon.Client.UWP.Services.GameServices
{
    public class GameService
    {
        public static GameService Instance { get; }
        static GameService()
        {
            // implement singleton pattern
            Instance = Instance ?? new GameService();
        }

        bool _IsLoggedIn = false;
        public bool IsLoggedIn { 
            get
            {
                return _IsLoggedIn;
            }
            set
            {
                _IsLoggedIn = value;
                // TODO: dispatch a message to the shell to show/hide the post-auth buttons
            }
        }
    }
}

