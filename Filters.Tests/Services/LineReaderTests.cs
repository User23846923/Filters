using Filters.Services;
using NUnit.Framework;

namespace Filters.Tests
{
    public class LineReaderTests
    {
        [Test]
        public void NextLineWorks()
        {
            // Assemble
            var expected = new string[] { "Ant", "Bat", "Cat", "Dog" };

            // Act
            var reader = new LineReader("LineReaderTestInput.txt");

            // Assert
            var expectedIndex = 0;
            foreach (var line in reader.GetNextLine())
            {
                Assert.AreEqual(line, expected[expectedIndex++]);
            }
        }
    }
}
