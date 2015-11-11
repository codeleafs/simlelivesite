using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simle.System.Kit.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;

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

        [TestMethod]
        public void SerializableTest()
        {
            BinarySerializer serializer = new BinarySerializer();

            SerializableObject obj1 = new SerializableObject() { Name = "test" };
            serializer.Serialize(obj1);

            try
            {
                NonSerializableObject obj2 = new NonSerializableObject() { Name = "test" };
                serializer.Serialize(obj2);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(SerializationException));
            }
        }
    }

    [Serializable]
    public class SerializableObject
    {
        public string Name { get; set; }
    }

    public class NonSerializableObject
    {
        public string Name { get; set; }
    }
}
