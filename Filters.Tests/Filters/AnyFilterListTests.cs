using Filters.Filters;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Filters.Tests
{
    public class AnyFilterListTests
    {
        [Test]
        public void CallsAllFiltersWhileFalse()
        {
            // Assemble
            var mockFilter1 = new Mock<IWordFilter>();
            mockFilter1
                .Setup(f => f.WordMatchesCondition(It.IsAny<string>()))
                .Returns(false);

            var mockFilter2 = new Mock<IWordFilter>();
            mockFilter2
                .Setup(f => f.WordMatchesCondition(It.IsAny<string>()))
                .Returns(false);

            var filterList = new AnyFilterList(new List<IWordFilter>
            { 
                mockFilter1.Object, 
                mockFilter2.Object 
            });

            // Act
            var isMatching = filterList.WordMatchesCondition("Ant");

            // Assert
            Assert.IsFalse(isMatching);
            mockFilter1.Verify(f => f.WordMatchesCondition(It.IsAny<string>()), Times.Once);
            mockFilter2.Verify(f => f.WordMatchesCondition(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void StopsAtFirstTrue()
        {
            // Assemble
            var mockFilter1 = new Mock<IWordFilter>();
            mockFilter1
                .Setup(f => f.WordMatchesCondition(It.IsAny<string>()))
                .Returns(true);

            var mockFilter2 = new Mock<IWordFilter>();
            mockFilter2
                .Setup(f => f.WordMatchesCondition(It.IsAny<string>()))
                .Returns(false);

            var filterList = new AnyFilterList(new List<IWordFilter>
            {
                mockFilter1.Object,
                mockFilter2.Object
            });

            // Act
            var isMatching = filterList.WordMatchesCondition("Ant");

            // Assert
            Assert.IsTrue(isMatching);
            mockFilter1.Verify(f => f.WordMatchesCondition(It.IsAny<string>()), Times.Once);
            mockFilter2.Verify(f => f.WordMatchesCondition(It.IsAny<string>()), Times.Never);
        }
    }
}
