namespace Roborally.Server.Tests
{
    using System;

    using Roborally.Communication.ServerInterfaces;

    /// <summary>The test register.</summary>
    public class TestRegister : IRegister
    {
        public string ID { get; set; }

        public IOrderCard Content { get; set; }

        public bool IsAvailable { get; set; }
    }
}