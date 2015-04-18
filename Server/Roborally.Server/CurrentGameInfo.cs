using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Server
{
    public class CurrentGameInfo : ICurrentGameInfo
    {
        public CurrentGameInfo()
        {
            this.InitRegisters();
            //this.InitPlayers(numberOfPlayers);
            this.CurrentState = GameStateEnum.DrawCards;

        }


        public IBoard Board { get; set; }
        public GameStateEnum CurrentState { get; set; }
        public IEnumerable<IGameRobot> GameRobots { get; set; }
        public IEnumerable<IRegister> Registers { get; set; }



        private void InitRegisters()
        {
            
        }

        //private void InitPlayers(int numberOfPlayers)
        //{
        //    for (int i = 0; i < numberOfPlayers; i++)
        //    {
        //        this.Registers.Add(new Register());
        //    }
        //}
    }
}