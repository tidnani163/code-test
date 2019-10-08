using AddressBook.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace AddressBook.Tests
{
    public class CsvReaderTests
    {
        private Mock<ILogger<CsvReader>> _logger;
        private CsvReader classUnderTest;

        public CsvReaderTests()
        {
            _logger = new Mock<ILogger<CsvReader>>();
            classUnderTest = new CsvReader(_logger.Object);
        }

        [Fact]
        public void TestLoadAddressBookSuccess()
        {
            var result = classUnderTest.LoadAddressBook();
            Assert.Equal(5, result.Count);
        }
    }
}
