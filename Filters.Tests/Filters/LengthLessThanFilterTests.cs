using Filters.Filters;
using NUnit.Framework;

namespace Filters.Tests.Filters
{
    public class LengthLessThanFilterTests
    {
        [Test]
        public void LengthEqualsReturnsFalse()
        {
            // Assemble
            var filter = new LengthLessThanFilter(3);

            // Act
            var isMatching = filter.WordMatchesCondition("Ant");

            // Assert
            Assert.IsFalse(isMatching);
        }

        [Test]
        public void LengthLessReturnsTrue()
        {
            // Assemble
            var filter = new LengthLessThanFilter(4);

            // Act
            var isMatching = filter.WordMatchesCondition("Ant");

            // Assert
            Assert.IsTrue(isMatching);
        }
    }
}
