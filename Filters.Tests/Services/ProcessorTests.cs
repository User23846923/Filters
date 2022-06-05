using Filters.Filters;
using Filters.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Filters.Tests.Services
{
    public class ProcessorTests
    {
        [Test]
        public void ProcessTokenLoopWorks()
        {
            // Assemble
            var filterList = new AnyFilterList(new List<IWordFilter> {
                new LengthLessThanFilter(3),
            });
            var processor = new Processor();

            // Act
            var separator = "";
            var sb = new StringBuilder();
            foreach (var token in new[] { "ab", ",", "123", ":", "xy", "!", "1234" })
            {
                processor.ProcessToken(token, filterList, (s) => sb.Append(s), ref separator);
            }

            // Assert
            Assert.AreEqual(", 123:! 1234", sb.ToString());
        }
    }
}
