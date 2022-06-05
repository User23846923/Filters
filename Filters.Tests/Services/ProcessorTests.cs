using Filters.Filters;
using Filters.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Filters.Tests.Services
{
    public class ProcessorTests
    {
        [Test]
        public void ProcessTokensWorks()
        {
            // Assemble
            var mockTokenizer = new Mock<ITokenizer>();
            mockTokenizer
                .Setup(x => x.GetNextToken())
                .Returns(GetMockTokens());

            var filterList = new AnyFilterList(new List<IWordFilter> {
                new LengthLessThanFilter(3),
            });
            var processor = new Processor(mockTokenizer.Object, filterList);

            // Act
            var sb = new StringBuilder();
            processor.ProcessTokens((s) => sb.Append(s));

            // Assert
            Assert.AreEqual(", 123:! 1234", sb.ToString());
        }

        private static IEnumerable<string> GetMockTokens()
        {
            yield return "ab";
            yield return ",";
            yield return "123";
            yield return ":";
            yield return "xy";
            yield return "!";
            yield return "1234";
        }
    }
}
