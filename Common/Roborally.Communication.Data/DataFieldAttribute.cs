using System;

namespace Roborally.Communication.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DataFieldAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="DataFieldAttribute"/> class.</summary>
        public DataFieldAttribute()
        {
            this.Code = 0;
            this.IsOptional = true;
        }

        public byte Code;

        public bool IsOptional;
    }
}
