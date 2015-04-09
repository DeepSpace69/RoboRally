using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using Roborally.Communication.Data.DataContracts;

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
            var knownTypes = GetAllTypes(toSerialize);
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
        public static Dictionary<byte, object> ToPhotonParameters(this object toSerialize)
        {
            return new Dictionary<byte, object>() { { 1, SerializeToXml(toSerialize) } };
        }


        private static Type[] GetAllTypes(object targer)
        {
            var extraTypes = new List<Type>();

            var type = targer.GetType();
            var properties = type.GetProperties()
                                    .Where(p => p.PropertyType.IsInterface)
                                    .Select(p => p.GetValue(targer, null)).ToList();

            foreach (var property in properties)
            {
                if (property == null)
                {
                    continue;
                }

                var propertyType = property.GetType();

                extraTypes.Add(propertyType);

                var elementType = propertyType.GetElementType();
                if (elementType != null)
                {
                    extraTypes.Add(elementType);
                }

                extraTypes.AddRange(propertyType.GetGenericArguments());

                var subTypes = GetAllTypes(property);
                extraTypes.AddRange(subTypes);

                var collection = property as IEnumerable;
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        var subTypesCollectionItem = GetAllTypes(item);
                        extraTypes.AddRange(subTypesCollectionItem);
                    }
                }
            }

            return extraTypes.Distinct().ToArray();
        }
    }
}
