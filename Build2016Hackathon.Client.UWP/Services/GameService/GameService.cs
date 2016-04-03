using System;
using System.Net;
using System.Net.Sockets;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;
using Build2016Hackathon.Client.UWP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Build2016Hackathon.Client.UWP.Services.GameServices
{
    public class GameService
    {

        private static ObservableCollection<Rating> _ratingBacking = new ObservableCollection<Rating>(new List<Rating>());

        private static ObservableCollection<Card> _cardBacking = new ObservableCollection<Card>(new List<Card>());

        public static GameService Instance { get; }


        public ReadOnlyObservableCollection<Rating> Ratings
        {
            get
            {
                return new ReadOnlyObservableCollection<Rating>(_ratingBacking);
            }
        }

        static GameService()
        {
            // implement singleton pattern
            Instance = Instance ?? new GameService();
        }

        internal Rating GetRating(ulong ratingId)
        {
            if (_ratingBacking == null)
            {
                refershData();
            }
            foreach (Rating rating in _ratingBacking )
            {
                if( rating.Id == ratingId )
                {
                    return rating;
                }
            }
            return null;

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

        public async void refershData()
        {
            if (_ratingBacking.Count == 0) {
                (await getListFromServerAsync<Rating>()).ForEach((rating) => _ratingBacking.Add(rating));
            }
 
            List<Card> updatedCards = new List<Card>(await getListFromServerAsync<Card>());
            // remove cards that are now invalid
            _cardBacking.ForEach((card) =>
            {
                if (updatedCards.Contains(card))
                {
                    updatedCards.Remove(card);
                }
                else
                {
                    _cardBacking.Remove(card);
                }
            });

            // Add new cards
            updatedCards.ForEach((card) =>
            {
                _cardBacking.Add(card);
            });

            if(_cardBacking.Count == 0 )
            {
                _cardBacking.Add(new Card { Text = "No Cards Found" });
            }
            Debug.WriteLine("Stuff is here");
        }

        public Player CurrentPlayer { get; set; }

        public ReadOnlyObservableCollection<Card> Cards
        {
            get
            {
                return new ReadOnlyObservableCollection<Card>(_cardBacking);
            }
        }

        public async void SetPlayer(string name)
        {
            Player newPlayer = new Player() { Handle = name };
            await App.client.GetTable<Player>().InsertAsync(newPlayer);
            CurrentPlayer = newPlayer;
        }

        
        public async Task<IEnumerable<Rating>> GetRatings()
        {
            return await getListFromServerAsync<Rating>();
        }
    
        public async Task<IEnumerable<T>> getEnumerableFromServerAsync<T>() {
            return await App.client.GetTable<T>().ToEnumerableAsync();
        }   

        public async Task<List<T>> getListFromServerAsync<T>()
        {
            return await App.client.GetTable<T>().ToListAsync();
        }
    }
}

