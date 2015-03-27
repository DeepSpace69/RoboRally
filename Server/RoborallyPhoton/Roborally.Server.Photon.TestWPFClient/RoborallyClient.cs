using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Client.Photon;

namespace Roborally.Server.Photon.TestClient
{
    public class RoborallyClient : IPhotonPeerListener, INotifyPropertyChanged
    {
        private bool connected;
        private string status;
        private PhotonPeer peer;

        public RoborallyClient()
        {
            this.peer = new PhotonPeer(this, ConnectionProtocol.Tcp);

            Connect();
            ServPeer();

            //var buffer = new StringBuilder();
            //while (true)
            //{
            //    peer.Service();

            //    // read input
            //    if (Console.KeyAvailable)
            //    {
            //        ConsoleKeyInfo key = Console.ReadKey();
            //        if (key.Key != ConsoleKey.Enter)
            //        {
            //            // store input
            //            buffer.Append(key.KeyChar);
            //        }
            //        else
            //        {
            //            // send to server
            //            var parameters = new Dictionary<byte, object> { { 100, buffer.ToString() } };
            //            peer.OpCustom(1, parameters, true);
            //            buffer.Length = 0;
            //        }
            //    }
            //}
        }

        private async Task Connect()
        {

            // connect
            this.connected = false;
            peer.Connect("127.0.0.1:4530", "RoborallyServer");
        }

        private async Task ServPeer()
        {
            while (true)
            {
                peer.Service();
                await Task.Delay(1000);
            }
        }

        public void OnEvent(EventData eventData)
        {
        }

        public void DebugReturn(DebugLevel level, string message)
        {
        }

        public void OnOperationResponse(OperationResponse operationResponse)
        {
        }

        public void OnStatusChanged(StatusCode statusCode)
        {
            switch (statusCode)
            {
                case StatusCode.Connect:
                    this.connected = true;
                    break;
                case StatusCode.Disconnect:
                    Connect();
                    break;
            }

            this.Status = statusCode.ToString();
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DoWork()
        {
            var parameters = new Dictionary<byte, object> { { 101, "1" }, { 102, "1" } };
            peer.OpCustom(1, parameters, true);
        }
    }
}
