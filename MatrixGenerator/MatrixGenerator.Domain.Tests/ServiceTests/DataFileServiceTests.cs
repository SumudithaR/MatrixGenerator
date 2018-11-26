using System;
using System.IO;
using MatrixGenerator.Domain.Services;
using NUnit.Framework;

namespace MatrixGenerator.Domain.Tests.ServiceTests
{
    [TestFixture]
    public class DataFileServiceTests
    {
        private readonly DataFileService _dataFileService;

        public DataFileServiceTests()
        {
            _dataFileService = new DataFileService();
        }

        [Test]
        public void ReadDataFile_ThrowsArgumentException_WhenNoFilePathIsProvided()
        {
            // Arrange 
            const string expectedMessage = "Data file path is invalid or no such file exists.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => _dataFileService.ReadDataFile(string.Empty));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ReadDataFile_ThrowsArgumentException_WhenInvalidFilePathIsProvided()
        {
            // Arrange 
            const string expectedMessage = "Data file path is invalid or no such file exists.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => _dataFileService.ReadDataFile("C:\\TEST12.PRN"));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ReadDataFile_ReturnsReadValues_WhenValidFilePathIsProvided()
        {
            // Arrange 
            var testValues = new[] { 0.0532925166190, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            var testFilePath = Path.GetTempFileName();
            File.WriteAllText(testFilePath, string.Join("\n", testValues));

            // Act 
            var actualValues = _dataFileService.ReadDataFile(testFilePath);

            // Assert 
            Assert.AreEqual(testValues, actualValues);
        }

        [Test]
        public void ReadDataFile_ThrowsFormatException_WhenFileContainsNonFloatingPointNumbers()
        {
            // Arrange 
            const string expectedMessage = "Data file contains invalid or empty values.";
            var testValues = new[] { 0.0532925166190, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            var testFilePath = Path.GetTempFileName();
            File.WriteAllText(testFilePath, string.Join("\n", testValues) + "\nabcd");

            // Act 
            var actualException = Assert.Throws<FormatException>(() => _dataFileService.ReadDataFile(testFilePath));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ReadDataFile_ThrowsFormatException_WhenFileContainsEmptyValues()
        {
            // Arrange 
            const string expectedMessage = "Data file contains invalid or empty values.";
            var testValues = new[] { 0.0532925166190, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            var testFilePath = Path.GetTempFileName();
            File.WriteAllText(testFilePath, string.Join("\n", testValues) + "\n ");

            // Act 
            var actualException = Assert.Throws<FormatException>(() => _dataFileService.ReadDataFile(testFilePath));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ReadDataFile_ThrowsOverflowException_WhenFileContainsTooSmallValues()
        {
            // Arrange 
            const string expectedMessage = "Data file contains too small or too large floating point numbers.";
            var testValues = new[] { double.MinValue - 1, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            var testFilePath = Path.GetTempFileName();
            File.WriteAllText(testFilePath, string.Join("\n", testValues));

            // Act 
            var actualException = Assert.Throws<OverflowException>(() => _dataFileService.ReadDataFile(testFilePath));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ReadDataFile_ThrowsOverflowException_WhenFileContainsTooLargeValues()
        {
            // Arrange 
            const string expectedMessage = "Data file contains too small or too large floating point numbers.";
            var testValues = new[] { double.MaxValue + 1, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            var testFilePath = Path.GetTempFileName();
            File.WriteAllText(testFilePath, string.Join("\n", testValues));

            // Act 
            var actualException = Assert.Throws<OverflowException>(() => _dataFileService.ReadDataFile(testFilePath));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }
    }
}