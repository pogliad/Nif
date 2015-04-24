using System;
using Nif.Core;
using Nif.Core.Extensions;
using NUnit.Framework;

namespace Nif.Tests.Core.Extensions
{
    using System.Runtime.Serialization;

    [TestFixture]
    public class BinaryExtensionsTests
    {
        [Test]
        public void WhenSerializeToMemory_WithSerializableObject_ReturnsNotNull()
        {
            // Arrange
            var obj = new SerializableObject
            {
                Property1 = 1,
                Property2 = "Property 1",
                Property3 = TimeProvider.Current.UtcNow
            };

            // Act
            var result = obj.SerializeToMemory();
            
            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public void WhenSerializeToMemory_WithNotSerializableObject_ThrowsException()
        {
            // Arrange
            var obj = new NotSerializableObject
            {
                Property1 = 1,
                Property2 = "Property 1",
                Property3 = TimeProvider.Current.UtcNow
            };

            // Act
            TestDelegate result = () => obj.SerializeToMemory();

            // Assert
            Assert.Throws<SerializationException>(result);
        }


        [Serializable]
        private class SerializableObject
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
            public DateTime Property3 { get; set; }
        }

        private class NotSerializableObject
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
            public DateTime Property3 { get; set; }
        }
    }
}