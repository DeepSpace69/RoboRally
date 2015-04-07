using System.Collections.Generic;


namespace Roborally.Communication.Data
{
    // Defines a base class that handles byte,object dictionary serialization for unified server/client operation and event definitions
    public class SerializableMapBase
    {
        public SerializableMapBase()
        {

        }


        public SerializableMapBase(Dictionary<byte, object> param)
        {
            ReflectiveMapSerializer.Deserialize(this, param);
        }


        public Dictionary<byte, object> ToParameters()
        {
            return ReflectiveMapSerializer.Serialize(this);
        }
    }
}
