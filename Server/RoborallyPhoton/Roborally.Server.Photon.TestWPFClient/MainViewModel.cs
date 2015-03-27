using Microsoft.Practices.Prism.Commands;
using Roborally.Server.Photon.TestClient;

namespace Roborally.Server.Photon.TestWPFClient
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Client = new RoborallyClient();
            this.ButtoDelegateCommand = new DelegateCommand(this.OnClick);
        }

        private void OnClick()
        {
            Client.DoWork();
        }

        public RoborallyClient Client { get; set; }

        public DelegateCommand ButtoDelegateCommand { get; set; }
    }
}