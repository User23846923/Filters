using Filters.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Filters.Tests
{
    public class TokenizerTests
    {
        [Test]
        public void GetNextTokenWorksSingleToken()
        {
            // Assemble
            var mockReader = new Mock<ILineReader>();
            mockReader
                .Setup(r => r.GetNextLine())
                .Returns(MockLinesSingleToken());

            var expected = new string[] { "Ant" };

            var tokenizer = new Tokenizer(mockReader.Object);

            // Act
            var expectedIndex = 0;
            foreach (var token in tokenizer.GetNextToken())
            {
                // Assert
                Assert.AreEqual(token, expected[expectedIndex++]);
            }
            Assert.AreEqual(expected.Length, expectedIndex);
        }

        [Test]
        public void GetNextTokenWorksSingleTokenTrailingWhitespace()
        {
            // Assemble
            var mockReader = new Mock<ILineReader>();
            mockReader
                .Setup(r => r.GetNextLine())
                .Returns(MockLinesSingleTokenTrailingWhitespace());

            var expected = new string[] { "Ant" };

            var tokenizer = new Tokenizer(mockReader.Object);

            // Act
            var expectedIndex = 0;
            foreach (var token in tokenizer.GetNextToken())
            {
                // Assert
                Assert.AreEqual(token, expected[expectedIndex++]);
            }
            Assert.AreEqual(expected.Length, expectedIndex);
        }

        [Test]
        public void GetNextTokenWorksSingleTokenTrailingPunctuation()
        {
            // Assemble
            var mockReader = new Mock<ILineReader>();
            mockReader
                .Setup(r => r.GetNextLine())
                .Returns(MockLinesSingleTokenTrailingPunctuation());

            var expected = new string[] { "Ant", "," };

            var tokenizer = new Tokenizer(mockReader.Object);

            // Act
            var expectedIndex = 0;
            foreach (var token in tokenizer.GetNextToken())
            {
                // Assert
                Assert.AreEqual(token, expected[expectedIndex++]);
            }
            Assert.AreEqual(expected.Length, expectedIndex);
        }

        [Test]
        public void GetNextTokenWorksSingleLine()
        {
            // Assemble
            var mockReader = new Mock<ILineReader>();
            mockReader
                .Setup(r => r.GetNextLine())
                .Returns(MockLinesSingleLine());

            var expected = new string[] { "Ant", "Bat" };

            var tokenizer = new Tokenizer(mockReader.Object);

            // Act
            var expectedIndex = 0;
            foreach (var token in tokenizer.GetNextToken())
            {
                // Assert
                Assert.AreEqual(token, expected[expectedIndex++]);
            }
            Assert.AreEqual(expected.Length, expectedIndex);
        }

        [Test]
        public void GetNextTokenWorksMultipleLines()
        {
            // Assemble
            var mockReader = new Mock<ILineReader>();
            mockReader
                .Setup(r => r.GetNextLine())
                .Returns(MockLinesMultiLine());

            var expected = new string[] { "Ant", "Bat", "Cat", "Dog" };

            var tokenizer = new Tokenizer(mockReader.Object);

            // Act
            var expectedIndex = 0;
            foreach (var token in tokenizer.GetNextToken())
            {
                // Assert
                Assert.AreEqual(token, expected[expectedIndex++]);
            }
            Assert.AreEqual(expected.Length, expectedIndex);
        }

        private static IEnumerable<string> MockLinesSingleToken()
        {
            yield return "Ant";
        }

        private static IEnumerable<string> MockLinesSingleTokenTrailingWhitespace()
        {
            yield return "Ant ";
        }

        private static IEnumerable<string> MockLinesSingleTokenTrailingPunctuation()
        {
            yield return "Ant,";
        }

        private static IEnumerable<string> MockLinesSingleLine()
        {
            yield return "Ant Bat";
        }

        private static IEnumerable<string> MockLinesMultiLine()
        {
            yield return "Ant Bat";
            yield return "Cat Dog";
        }
    }
}
