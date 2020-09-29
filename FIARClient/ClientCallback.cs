using FIARClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace FIARClient
{
    /// <summary>
    /// class for callbacks for the host to contact the clients
    /// </summary>
    public class ClientCallback : IFIARServiceCallback
    {
        public delegate bool invite(string username);

        public invite invatation;
        internal Action<List<PlayerInfo>> getPlayers;
        internal Action lostConnection;

        public delegate Task move(MoveResult result, int col);

        internal Action<MoveResult> EndGame;


        public move madeMove;
        /// <summary>
        /// updates the game given the other players move and result of the move
        /// </summary>
        /// <param name="result"></param>
        /// <param name="col"></param>
        public void OtherPlayerMoved(MoveResult result, int col)
        {
            if (MoveResult.YouWon == result)
            {
                madeMove(MoveResult.YouLost, col);
            }
            else
            {
                madeMove(result, col);
            }
            return;
        }


        /// <summary>
        /// notify this player that other player disconncted and sets the game as ended
        /// </summary>
        public void OtherPlayerDisconnected()
        {
            EndGame(MoveResult.PlayerLeft);
        }


        /// <summary>
        /// callback for clients to recives invtation
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool SendInvite(string username)
        {
            return invatation(username);

        }


        /// <summary>
        /// callback for host to know this user is still connected to host
        /// </summary>
        /// <returns></returns>
        public bool IsAlive()
        {
            return true;
        }



        /// <summary>
        /// updates clients with available players
        /// </summary>
        /// <param name="players"></param>
        public void UpdateClients(List<PlayerInfo> players)
        {
            getPlayers(players);
        }
    }
}
