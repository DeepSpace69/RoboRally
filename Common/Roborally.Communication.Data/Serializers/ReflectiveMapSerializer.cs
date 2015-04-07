namespace Roborally.Communication.Data
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>The reflective map serializer.</summary>
    public class ReflectiveMapSerializer
    {
        [ThreadStatic]
        private static ReflectiveMapSerializer instance;

        // Instance implementation
        private readonly Dictionary<Type, SerializedType> serializedTypeMap;

        /// <summary>Initializes a new instance of the <see cref="ReflectiveMapSerializer"/> class.</summary>
        public ReflectiveMapSerializer()
        {
            this.serializedTypeMap = new Dictionary<Type, SerializedType>();
        }

        // Lazy serializer instantiation
        // Serializer is thread static, which in a worst case scenario  can create per thread redundancy of serialized types definitions,
        // But does not require locking for type lookup.
        // Need to profile and see if this approach is better than locking during lookup        
        private static ReflectiveMapSerializer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReflectiveMapSerializer();
                }

                return instance;
            }
        }

        /// <summary>The serialize.</summary>
        /// <param name="obj">The object.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="Dictionary"/>.</returns>
        public static Dictionary<byte, object> Serialize<T>(T obj)
        {
            return Instance.DoSerialize(obj);
        }

        /// <summary>The deserialize.</summary>
        /// <param name="obj">The obj.</param>
        /// <param name="param">The param.</param>
        /// <typeparam name="T"></typeparam>
        public static void Deserialize<T>(T obj, Dictionary<byte, object> param)
        {
            Instance.DoDeserialize(obj, param);
        }

        // Resolve runtime type and update cache if necessary
        private SerializedType GetSerializedType<T>(T obj)
        {
            Type type = obj.GetType();

            if (!this.serializedTypeMap.ContainsKey(type))
            {
                SerializedType serializedType = new SerializedType(type);
                this.serializedTypeMap.Add(type, serializedType);
            }

            return this.serializedTypeMap[type];
        }

        private Dictionary<byte, object> DoSerialize<T>(T obj)
        {
            SerializedType type = this.GetSerializedType(obj);
            Dictionary<byte, object> map = new Dictionary<byte, object>();

            for (int i = 0; i < type.fields.Length; i++)
            {
                object val = type.fields[i].fieldInfo.GetValue(obj, null);
                byte code = type.fields[i].attribute.Code;
                bool opt = type.fields[i].attribute.IsOptional;

                if (val == null && !opt)
                {
                    throw new ArgumentNullException(type.fields[i].fieldInfo.Name);
                }
                else
                {
                    map.Add(code, val);
                }
            }

            return map;
        }

        private void DoDeserialize<T>(T obj, Dictionary<byte, object> param)
        {
            SerializedType type = this.GetSerializedType(obj);

            for (int i = 0; i < type.fields.Length; i++)
            {
                byte code = type.fields[i].attribute.Code;
                bool opt = type.fields[i].attribute.IsOptional;

                if (!param.ContainsKey(code) && !opt)
                {
                    throw new ArgumentNullException(type.fields[i].fieldInfo.Name);
                }
                else
                {
                    type.fields[i].fieldInfo.SetValue(obj, param[code], null);
                }
            }
        }

        private class SerializedType
        {
            /// <summary>The fields.</summary>
            public SerializedField[] fields;

            /// <summary>The type.</summary>
            public Type type;

            /// <summary>Initializes a new instance of the <see cref="SerializedType"/> class.</summary>
            /// <param name="t">The t.</param>
            public SerializedType(Type t)
            {
                this.type = t;

                PropertyInfo[] allFields = t.GetProperties();

                List<SerializedField> serializedFields = new List<SerializedField>();

                for (int i = 0; i < allFields.Length; i++)
                {
                    DataFieldAttribute attr =
                        (DataFieldAttribute)Attribute.GetCustomAttribute(allFields[i], typeof(DataFieldAttribute));

                    if (attr != null)
                    {
                        serializedFields.Add(new SerializedField(allFields[i], attr));
                    }
                }

                this.fields = serializedFields.ToArray();
            }
        }

        private class SerializedField
        {
            /// <summary>The attribute.</summary>
            public DataFieldAttribute attribute;

            /// <summary>The field info.</summary>
            public PropertyInfo fieldInfo;

            /// <summary>Initializes a new instance of the <see cref="SerializedField"/> class.</summary>
            /// <param name="field">The field.</param>
            /// <param name="attr">The attr.</param>
            public SerializedField(PropertyInfo field, DataFieldAttribute attr)
            {
                this.fieldInfo = field;
                this.attribute = attr;
            }
        }
    }
}