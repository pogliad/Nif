using System.Collections.Generic;
using FluentAssertions;
using Nif.Core.Utilities;
using NUnit.Framework;

namespace Nif.Tests.Core.Utilities
{
    using System.ComponentModel;

    [TestFixture]
    public class EnumUtilityTests
    {
        [Test]
        public void GetEnumeratorDescription_WithAnyEnumerator_ReturnsCorrectDescriptionForSelectedEnumerator()
        {
            // Arrange                                
            const FakeEnum Enumerator = FakeEnum.Enumerator1;
            const string Expected = "Enumerator1 Description";

            // Act
            var result = EnumUtility.GetEnumeratorDescription(Enumerator);

            // Assert
            Expected.ShouldBeEquivalentTo(result);
        }

        [Test]
        public void GetEnumeratorDescriptions_WithAnyEnumerators_ReturnsCorrectDescriptions()
        {
            // Arrange
            var expected = new List<string>
                {
                    "Enumerator1 Description",
                    "Enumerator2 Description",
                    "Enumerator3 Description"
                };

            // Act
            var result = EnumUtility.GetEnumeratorDescriptions<FakeEnum>();

            // Assert
            expected.ShouldAllBeEquivalentTo(result);
        }

        private enum FakeEnum
        {
            [Description("Enumerator1 Description")]
            Enumerator1,
            [Description("Enumerator2 Description")]
            Enumerator2,
            [Description("Enumerator3 Description")]
            Enumerator3
        }        
    }
}