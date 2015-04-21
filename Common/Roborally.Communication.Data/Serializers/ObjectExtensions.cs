using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Roborally.Communication.Data
{
    /// <summary>
    /// Extension methods for <see cref="Object"/>
    /// </summary>
    public static class ObjectExtensions
    {
        private static readonly Type[] knownTypes;

        static ObjectExtensions()
        {
            knownTypes = typeof(ObjectExtensions).Assembly.GetTypes()
                                                 .Where(
                                                     p => p.GetCustomAttributes(true)
                                                           .Any(a => a is DataContractAttribute))
                                                 .ToArray();
        }

        /// <summary>Serialize object to xml.</summary>
        /// <param name="toSerialize">The object to serialize.</param>
        /// <returns>String that contain xml as result of serialization.</returns>
        public static string SerializeToXml(this object toSerialize)
        {
            var serializer = new DataContractSerializer(toSerialize.GetType(), knownTypes);
            using (var stringWriter = new StringWriter())
            {
                var xmlTextWriter = new XmlTextWriter(stringWriter);
                serializer.WriteObject(xmlTextWriter, toSerialize);
                var result = stringWriter.ToString();
                return result;
            }
        }

        /// <summary>Serialize object to photon parameters.</summary>
        /// <param name="toSerialize">Object to serialize.</param>
        /// <returns>Parameters to send.</returns>
        public static Dictionary<byte, object> ToXmlPhotonParameters(this object toSerialize)
        {
            return new Dictionary<byte, object>() { { 1, SerializeToXml(toSerialize) } };
        }

        public static Dictionary<byte, object> ToDictionary(this object toSerialize)
        {
            return ReflectiveMapSerializer.Serialize(toSerialize);
        }

        public static T Deserialize<T>(this string rawXml)
        {
            using (var reader = XmlReader.Create(new StringReader(rawXml)))
            {
                var deserializer =
                    new DataContractSerializer(typeof(T), knownTypes);
                var result = (T)deserializer.ReadObject(reader);
                return result;
            }
        }

        public static T Deserialize<T>(this Dictionary<byte, object> dictionary) where T : class
        {
            var result = Activator.CreateInstance<T>();
            ReflectiveMapSerializer.Deserialize(result, dictionary);
            return result;
        }
    }
}
