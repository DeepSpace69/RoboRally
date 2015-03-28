using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roborally.Communication.Data.Tests
{
    using System.Collections.Generic;

    [TestClass]
    public class SerializableMapBaseTests
    {
        [TestMethod]
        public void ToParameters_SimpleObject_SuccessSerialize()
        {
            var test = new TestClass("test", 7);

            var actual = test.ToParameters();

            Assert.AreEqual("test", actual[1]);
            Assert.AreEqual(7, actual[2]);
        }

        [TestMethod]
        public void Deserialize_SimpleObject_SuccessSerialize()
        {
            var test = new Dictionary<byte, object>() { { 1, "test" }, { 2, 7 } };

            var actual = new TestClass(test);

            Assert.AreEqual("test", actual.StringProperty);
            Assert.AreEqual(7, actual.IntProperty);
        }

        public class TestClass : SerializableMapBase
        {
            public TestClass(string stringProperty, int intProperty)
                : base()
            {
                this.StringProperty = stringProperty;
                this.IntProperty = intProperty;
            }

            public TestClass(Dictionary<byte, object> param)
                : base(param)
            {

            }

            [DataFieldAttribute(Code = 1, IsOptional = false)]
            public string StringProperty { get; set; }

            [DataFieldAttribute(Code = 2, IsOptional = false)]
            public int IntProperty { get; set; }
        }
    }
}
