using FIARClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace FIARClient
{
    public class ClientCallback : IFIARServiceCallback
    {
        public delegate bool invite(string username);

        public invite invatation;
        internal Action<List<PlayerInfo>> getPlayers;

        public delegate Task move(MoveResult result, int col);
        public move madeMove;
        public void OtherPlayerMoved(MoveResult result, int col)
        {
            madeMove(result, col);
            //var task = Task.Run(async () => await madeMove(col));
            //await madeMove(col);
            //task.RunSynchronously();
            return;
        }

        public bool SendInvite(string username)
        {
            bool res = invatation(username);
            return res;
        }



        public void StartGame()
        {
            return;
        }


        public void UpdateClients(List<PlayerInfo> players)
        {
            getPlayers(players);
        }
    }
}
