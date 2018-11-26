using System;
using System.Linq;
using MatrixGenerator.Domain.Services;
using NUnit.Framework;

namespace MatrixGenerator.Domain.Tests.ServiceTests
{
    [TestFixture]
    public class MatrixServiceTests
    {
        private readonly MatrixService _matrixService;

        public MatrixServiceTests()
        {
            _matrixService = new MatrixService();
        }

        [Test]
        public void GenerateMatrix_ThrowsArgumentException_WhenNoDataValuesAreProvided()
        {
            // Arrange 
            const string expectedMessage = "No data values were provided.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => _matrixService.GenerateMatrix(Array.Empty<double>(), 4, 300));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void GenerateMatrix_ThrowsArgumentException_WhenDataValuesIsNull()
        {
            // Arrange 
            const string expectedMessage = "No data values were provided.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => _matrixService.GenerateMatrix(null, 4, 300));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void GenerateMatrix_ThrowsArgumentException_WhenValueOfNIsLessThanCPlusOne()
        {
            // Arrange 
            const string expectedMessage = "Value of \"N\" must be greater than or equal to (\"c\" + 1) to generate the matrix.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => _matrixService.GenerateMatrix(new double[5], 4, 4));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void GenerateMatrix_ThrowsArgumentException_WhenValueOfNIsGreaterThanNoOfDataValues()
        {
            // Arrange 
            const string expectedMessage = "Value of \"N\" must be less than or equal to the number of input data values to generate the matrix.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => _matrixService.GenerateMatrix(new double[5], 0, 6));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void GenerateMatrix_ThrowsArgumentException_WhenValueOfCIsLessThanZero()
        {
            // Arrange 
            const string expectedMessage = "Value of \"c\" must be greater than or equal to zero to generate the matrix.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => _matrixService.GenerateMatrix(new double[5], -1, 5));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void GenerateMatrix_ReturnsOneByOneMatrix_WhenCIsZeroAndNIsTwoAndValidDataFileIsPresent()
        {
            // Arrange 
            var testValues = new[] { 0.0532925166190, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            var expectedMatrixString = " 0.002840 \r\n";


            // Act 
            var actualMatrixString = _matrixService.GenerateMatrix(testValues, 0, 1);

            // Assert 
            Assert.AreEqual(expectedMatrixString, actualMatrixString);
        }

        [Test]
        public void GenerateMatrix_ReturnsFiveByFiveMatrix_WhenCIsFourAndNIsFiveAndValidDataFileIsPresent()
        {
            // Arrange 
            var testValues = new[] { 0.0532925166190, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            var expectedMatrixString = " 0.001085  0.001362  0.001571  0.001702  0.001755 \r\n 0.001362  0.001711  0.001973  0.002137  0.002204 " +
                                       "\r\n 0.001571  0.001973  0.002274  0.002464  0.002542 \r\n 0.001702  0.002137  0.002464  0.002670  0.002754 " +
                                       "\r\n 0.001755  0.002204  0.002542  0.002754  0.002840 \r\n";

            // Act 
            var actualMatrixString = _matrixService.GenerateMatrix(testValues, 4, 5);

            // Assert 
            Assert.AreEqual(expectedMatrixString, actualMatrixString);
        }

        [Test]
        public void GenerateMatrix_ReturnsSquareMatrix_WhenCIsValidAndNIsValidAndValidDataFileIsPresent()
        {
            // Arrange 
            var testValues = new[] { 0.0532925166190, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468 };
            const int expectedRowColumnCount = 4;
            const int expectedCellCount = 16;

            // Act 
            var actualMatrixString = _matrixService.GenerateMatrix(testValues, 3, 5);
            var actualFirstRowColumnCount = actualMatrixString.Substring(0, actualMatrixString.IndexOf('\r')).Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
            var actualRowCount = actualMatrixString.Split('\r').Count(x => !x.Equals("\n"));
            var actualTotalCellCount = actualMatrixString.Split(new[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

            // Assert 
            Assert.AreNotEqual(string.Empty, actualMatrixString);
            Assert.AreEqual(expectedRowColumnCount, actualFirstRowColumnCount);
            Assert.AreEqual(expectedRowColumnCount, actualRowCount);
            Assert.AreEqual(expectedCellCount, actualTotalCellCount);
        }
    }
}