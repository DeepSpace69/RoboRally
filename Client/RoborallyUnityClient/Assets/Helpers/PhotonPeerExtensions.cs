using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
    /// <summary>The photon peer extensions.</summary>
    public static class PhotonPeerExtensions
    {
        /// <summary>The op custom.</summary>
        /// <param name="peer">The peer.</param>
        /// <param name="operationCode">The operation code.</param>
        public static void OpCustom(this PhotonPeer peer, byte operationCode)
        {
            peer.OpCustom(operationCode, new Dictionary<byte, object>(), true);
        }

        /// <summary>The op custom.</summary>
        /// <param name="peer">The peer.</param>
        /// <param name="operationCode">The operation code.</param>
        /// <param name="parameters">The parameters.</param>
        public static void OpCustom(this PhotonPeer peer, byte operationCode, Dictionary<byte, object> parameters)
        {
            peer.OpCustom(operationCode, parameters, true);
        }
    }
}
