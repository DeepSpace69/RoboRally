using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Roborally.Communication.Data
{
    /// <summary>
    /// Extension methods for <see cref="Object"/>
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>Serialize object to xml.</summary>
        /// <param name="toSerialize">The object to serialize.</param>
        /// <returns>String that contain xml as result of serialization.</returns>
        public static string SerializeToXml(this object toSerialize)
        {
            if (toSerialize == null)
            {
                return null;
            }

            var xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, toSerialize);
                return stringWriter.ToString();
            }
        }

        /// <summary>Serialize object to photon parameters.</summary>
        /// <param name="toSerialize">Object to serialize.</param>
        /// <returns>Parameters to send.</returns>
        public static Dictionary<byte, object> ToPhotonParameters(this object toSerialize)
        {
            return new Dictionary<byte, object>() { { 1, SerializeToXml(toSerialize) } };
        }
    }
}
