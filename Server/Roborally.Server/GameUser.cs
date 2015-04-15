using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roborally.Server.BoardObjects;

namespace Roborally.Server
{
    internal class GameUser
    {
        internal GameUser(User incomingUser)
        {
            this.user = incomingUser;
            this.InitRegisters();
        }

        internal User user;

        internal List<Register> registers;

        internal GameRobot gameRobot;

        private void InitRegisters()
        {
            for (int i = 0; i < 5; i++)
            {
                this.registers.Add(new Register(i));
            }
        }

    }
}