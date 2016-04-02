using System;
using System.Net;
using System.Net.Sockets;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;
using Build2016Hackathon.Client.UWP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        private void Args_Completed(object sender, SocketAsyncEventArgs e)
        {
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

        public Player CurrentPlayer { get; set; }

        public async void SetPlayer(string name)
        {
            Player newPlayer = new Player() { Handle = name };
            await App.client.GetTable<Player>().InsertAsync(newPlayer);
            CurrentPlayer = newPlayer;
        }

        public async Task<IEnumerable<Rating>> GetRatings()
        {
            return await App.client.GetTable<Rating>().ToListAsync();
        }
    }
}

