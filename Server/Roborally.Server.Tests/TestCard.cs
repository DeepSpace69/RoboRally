namespace Roborally.Server.Tests
{
    using Roborally.Communication.ServerInterfaces;

    /// <summary>The test card.</summary>
    public class TestCard : IOrderCard
    {
        /// <summary>Gets or sets the id.</summary>
        public string ID { get; set; }

        /// <summary>Gets or sets the energy.</summary>
        public int Energy { get; set; }

        /// <summary>Gets or sets the speed.</summary>
        public int Speed { get; set; }

        /// <summary>Gets or sets the type.</summary>
        public MoveDirectionEnum Type { get; set; }
    }
}