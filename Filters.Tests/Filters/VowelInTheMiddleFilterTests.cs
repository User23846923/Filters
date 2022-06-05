using Filters.Filters;
using NUnit.Framework;

namespace Filters.Tests
{
    public class VowelInTheMiddleFilterTests
    {
        [TestCase("Y")]
        [TestCase("Ant")]
        [TestCase("Into")]
        public void VowelNotPresentReturnsFalse(string word)
        {
            // Assemble
            var filter = new VowelInTheMiddleFilter();

            // Act
            var isMatching = filter.WordMatchesCondition(word);

            // Assert
            Assert.IsFalse(isMatching);
        }

        [TestCase("a-")]
        [TestCase("e-")]
        [TestCase("i-")]
        [TestCase("o-")]
        [TestCase("u-")]
        [TestCase("A-")]
        [TestCase("E-")]
        [TestCase("I-")]
        [TestCase("O-")]
        [TestCase("U-")]

        [TestCase("-a")]
        [TestCase("-e")]
        [TestCase("-i")]
        [TestCase("-o")]
        [TestCase("-u")]
        [TestCase("-A")]
        [TestCase("-E")]
        [TestCase("-I")]
        [TestCase("-O")]
        [TestCase("-U")]

        [TestCase("-a-")]
        [TestCase("-e-")]
        [TestCase("-i-")]
        [TestCase("-o-")]
        [TestCase("-u-")]
        [TestCase("-A-")]
        [TestCase("-E-")]
        [TestCase("-I-")]
        [TestCase("-O-")]
        [TestCase("-U-")]

        [TestCase("-a--")]
        [TestCase("-e--")]
        [TestCase("-i--")]
        [TestCase("-o--")]
        [TestCase("-u--")]
        [TestCase("-A--")]
        [TestCase("-E--")]
        [TestCase("-I--")]
        [TestCase("-O--")]
        [TestCase("-U--")]

        [TestCase("--a-")]
        [TestCase("--e-")]
        [TestCase("--i-")]
        [TestCase("--o-")]
        [TestCase("--u-")]
        [TestCase("--A-")]
        [TestCase("--E-")]
        [TestCase("--I-")]
        [TestCase("--O-")]
        [TestCase("--U-")]
        public void VowelPresentReturnsTrue(string word)
        {
            // Assemble
            var filter = new VowelInTheMiddleFilter();

            // Act
            var isMatching = filter.WordMatchesCondition(word);

            // Assert
            Assert.IsTrue(isMatching);
        }
    }
}
