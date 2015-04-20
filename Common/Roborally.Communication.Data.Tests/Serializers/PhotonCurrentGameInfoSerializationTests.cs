using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Roborally.Communication.Data.DataContracts;
using Roborally.Communication.ServerInterfaces;

namespace Roborally.Communication.Data.Tests.Serializers
{
    [TestClass]
    public class PhotonCurrentGameInfoSerializationTests
    {
        [TestMethod]
        public void PhotonCurrentGameInfoSerialization_Serialize_DeserializedObjectSuccess()
        {
            var actual = this.CreatePhotonCurrentGameInfo();
            var deserialized = actual.SerializeToXml()
                                     .Deserialize<PhotonCurrentGameInfo>();

            Assert.AreEqual(actual.CurrentState, deserialized.CurrentState);
        }

        private PhotonCurrentGameInfo CreatePhotonCurrentGameInfo()
        {
            var result = new PhotonCurrentGameInfo();
            
            result.CurrentState = GameStateEnum.DrawCards;
            result.Board = this.CreateBoard();

            return result;
        }

        private IBoard CreateBoard()
        {
            return null;
        }
    }
}
