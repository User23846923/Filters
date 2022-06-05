using Filters.Filters;
using NUnit.Framework;

namespace Filters.Tests
{
    public class ContainsCharacterFilterTests
    {
        [Test]
        public void CharacterNotPresentReturnsFalse()
        {
            // Assemble
            var filter = new ContainsCharacterFilter('z');

            // Act
            var isMatching = filter.WordMatchesCondition("Ant");

            // Assert
            Assert.IsFalse(isMatching);
        }

        [Test]
        public void CharacterPresentReturnsTrue()
        {
            // Assemble
            var filter = new ContainsCharacterFilter('A');

            // Act
            var isMatching = filter.WordMatchesCondition("Ant");

            // Assert
            Assert.IsTrue(isMatching);
        }
    }
}
