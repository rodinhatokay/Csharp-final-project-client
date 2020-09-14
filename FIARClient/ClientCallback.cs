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
        public void OtherPlayerMoved(MoveResult result, int col)
        {
            throw new NotImplementedException();
        }

        public bool SendInvite(string username)
        {
            bool res = invatation(username);
            return res;
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
