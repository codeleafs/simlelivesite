using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simle.System.Kit.Serialization;
using System.IO;
using System.Collections.Generic;

namespace Simle.System.Kit.Tests.Serialization
{
    [TestClass]
    public class BinarySerializerTest
    {
        [TestMethod]
        public void SerializeTest()
        {
            BinarySerializer serializer = new BinarySerializer();
            MemoryStream stream = serializer.Serialize(new List<string>() { "f", "s" });

            Assert.IsNotNull(stream);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            BinarySerializer serializer = new BinarySerializer();
            var data = new List<string>() { "f", "s" };
            MemoryStream stream = serializer.Serialize(data);
            var obj2 = serializer.Deserializer<List<string>>(stream);

            Assert.AreEqual(data[0], obj2[0]);
        }
    }
}
