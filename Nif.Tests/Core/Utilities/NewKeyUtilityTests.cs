using Nif.Core.Utilities;
using NUnit.Framework;

namespace Nif.Tests.Core.Utilities
{
    [TestFixture]
    public class NewKeyUtilityTests
    {
        private const int KeyLength = 32;

        [Test]
        public void EnsureThat_NewKeyLength_IsEqualTo32()
        {
            // Arrange

            // Act
            var result = NewKeyUtility.GetNewKey();

            // Assert
            Assert.AreEqual(KeyLength, result.Length);            
        }
    }
}