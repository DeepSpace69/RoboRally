using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.DataContracts
{
    public class PhotonRobot : IRobot
    {
        /// <summary>Gets the id.</summary>
        public int Id { get; set; }

        /// <summary>Gets the model id.</summary>
        public int ModelId { get; set; }

        /// <summary>Gets the name.</summary>
        public string Name { get; set; }
    }
}
