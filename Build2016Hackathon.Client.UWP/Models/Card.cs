using Build2016Hackathon.Client.UWP.Services.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build2016Hackathon.Client.UWP.Models
{
    public class Card
    {
        public Card()
        {
            StatusId = 1;
        }
        public UInt64 Id { get; set; }
        public string Text { get; set; }
        public UInt64 RatingId { get; set; }
        public uint NumberOfAnswers { get; set; }
        public UInt64 StatusId { get; set; }
        
        public Rating Rating
        {
            get
            {
                return GameService.Instance.GetRating( RatingId );
            }
        }

        public CardType CardType
        {
            get
            {
                return NumberOfAnswers == 0 ? CardType.A : CardType.Q;
            }
        }
    }
}
