using System;
using MatrixGenerator.Console.Validators;
using NUnit.Framework;

namespace MatrixGenerator.Console.Tests.ValidatorTests
{
    [TestFixture]
    public class ParameterValidatorTests
    {
        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenLessThanRequiredParameterAreProvided()
        {
            // Arrange 
            const string expectedMessage = "Invalid parameters; data file path, value of \"c\" and value of \"N\" are required.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new string[0], out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenMoreThanRequiredParameterAreProvided()
        {
            // Arrange 
            const string expectedMessage = "Invalid parameters; data file path, value of \"c\" and value of \"N\" are required.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", "0", "5", "12" }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenDataFilePathIsNotProvided()
        {
            // Arrange 
            const string expectedMessage = "A data file path was not provided.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { null, "0", "5" }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenDataFilePathIsEmpty()
        {
            // Arrange 
            const string expectedMessage = "A data file path was not provided.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { string.Empty, "0", "5" }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenValueOfCIsNotProvided()
        {
            // Arrange 
            const string expectedMessage = "Value of \"c\" is required and must be an integer.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", null, "5" }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenValueOfCIsEmpty()
        {
            // Arrange 
            const string expectedMessage = "Value of \"c\" is required and must be an integer.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", string.Empty, "5" }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenValueOfCIsNotAnInteger()
        {
            // Arrange 
            const string expectedMessage = "Value of \"c\" is required and must be an integer.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", "5.5", "5" }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenValueOfNIsNotProvided()
        {
            // Arrange 
            const string expectedMessage = "Value of \"N\" is required and must be an integer.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", "0", null }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenValueOfNIsEmpty()
        {
            // Arrange 
            const string expectedMessage = "Value of \"N\" is required and must be an integer.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", "0", string.Empty }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_ThrowsArgumentException_WhenValueOfNIsNotAnInteger()
        {
            // Arrange 
            const string expectedMessage = "Value of \"N\" is required and must be an integer.";

            // Act 
            var actualException = Assert.Throws<ArgumentException>(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", "0", "5.444444" }, out int c, out int n));

            // Assert 
            Assert.AreEqual(expectedMessage, actualException.Message);
        }

        [Test]
        public void ValidateMatrixParameters_DoesNotThrowsExceptions_WhenAllValueAreValid()
        {
            // Arrange 
            const int expectedValueOfC = 1;
            const int expectedValueOfN = 5;
            int actualValueOfC = 0;
            int actualValueOfN = 0;

            // Act 
            Assert.DoesNotThrow(() => ParameterValidator.ValidateMatrixParameters(new[] { "C:\\TEST.PRN", "1", "5" }, out actualValueOfC, out actualValueOfN));

            // Assert 
            Assert.AreEqual(expectedValueOfC, actualValueOfC);
            Assert.AreEqual(expectedValueOfN, actualValueOfN);
        }
    }
}