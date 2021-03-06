﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Roborally.Communication.Data.Tests.Serializers
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void ToParameters_SimpleObject_SuccessSerialize()
        {
            var test = new BaseTestClass
                           {
                               IntProperty = 7,
                               StringProperty = "test"
                           };

            var parameters = test.ToXmlPhotonParameters();
            var xmlString = parameters[1].ToString();
            var actual = xmlString.Deserialize<BaseTestClass>();

            Assert.AreEqual("test", actual.StringProperty);
            Assert.AreEqual(7, actual.IntProperty);
        }

        [TestMethod]
        public void ToDictionary_SimpleObject_SuccessSerialize()
        {
            var test = new BaseTestClass
            {
                IntProperty = 7,
                StringProperty = "test"
            };

            var actual = test.ToDictionary();

            Assert.AreEqual("test", actual[1]);
            Assert.AreEqual(7, actual[2]);
        }

        [TestMethod]
        public void Deserialize_SimpleObject_SuccessSerialize()
        {
            var test = new Dictionary<byte, object>() { { 1, "test" }, { 2, 7 } };

            var actual = test.Deserialize<BaseTestClass>();

            Assert.AreEqual("test", actual.StringProperty);
            Assert.AreEqual(7, actual.IntProperty);
        }

        [TestMethod]
        public void Deserialize_ListSimpleObject_SuccessDeserialize()
        {
            var test = new List<BaseTestClass>()
                           {
                               new BaseTestClass() { IntProperty = 1, StringProperty = "1" },
                               new BaseTestClass() { IntProperty = 2, StringProperty = "2" },
                           };
            var target = test.ToXmlPhotonParameters();

            var actual = target[1].ToString().Deserialize<List<BaseTestClass>>();

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(1, actual[0].IntProperty);
            Assert.AreEqual(2, actual[1].IntProperty);
            Assert.AreEqual("1", actual[0].StringProperty);
            Assert.AreEqual("2", actual[1].StringProperty);
        }
    }
}
