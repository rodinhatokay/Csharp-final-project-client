using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIARClient.ServiceReference1;

namespace FIARClient
{
    public class player : PlayerInfo
    {
        public player(PlayerInfo p)
        {
            this.username = p.username;
            this.Score = p.Score;
            this.Loses = p.Loses;
            this.PlayedAgainst = p.PlayedAgainst;

        }
        public override string ToString()
        {
            return this.username;

        }
    }
}
