using Nif.Utilities;
using NUnit.Framework;

namespace Nif.Tests.Utilities
{
    [TestFixture]
    public class NewKeyUtilityTests
    {
        [Test]
        public void EnsureThat_NewKeyLength_IsEqualTo32()
        {
            // Arrange
            const int keyLength = 32;

            // Act
            var result = NewKeyUtility.GetNewKey();

            // Assert
            Assert.AreEqual(keyLength, result.Length);            
        }
    }
}