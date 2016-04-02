using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build2016Hackathon.Client.UWP.Models
{
    public class Card
    {
        public string Text;
        public UInt64 RatingId;
        public UInt64 NumberOfAnswers;
        public UInt64 StatusId = 1;
    }
}
