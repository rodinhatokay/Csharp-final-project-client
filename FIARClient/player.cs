using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIARClient.ServiceReference1;

namespace FIARClient
{

    /// <summary>
    /// this is extended version of player info used mainly for displaying info
    /// </summary>
    public class player : PlayerInfo
    {
        public player(PlayerInfo p)
        {
            this.id = p.id;
            this.username = p.username;
            this.Wins = p.Wins;
            this.Games = p.Games;
            this.Score = p.Score;
            this.Loses = p.Loses;
            this.Status = p.Status;

            this.PlayedAgainst = p.PlayedAgainst;

        }
        public override string ToString()
        {
            return this.username;

        }

        public static List<player> initList(List<PlayerInfo> l)
        {
            var newL = new List<player>();
            l.ForEach(p =>
            {
                newL.Add(new player(p));
            });
            return newL;
        }
    }
}
