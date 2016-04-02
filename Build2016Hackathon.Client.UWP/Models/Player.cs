using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build2016Hackathon.Client.UWP.Models
{
    public class Player
    {
        public UInt64 Id { get; set; }
        public String Handle { get; set; }
        public bool Admin { get; set; }
    }
}
