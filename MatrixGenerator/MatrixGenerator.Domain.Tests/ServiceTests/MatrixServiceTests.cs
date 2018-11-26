﻿using System;
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
            const string expectedMatrixString = " 0.001085  0.001362  0.001571  0.001702  0.001755 \r\n " +
                                                "0.001362  0.001711  0.001973  0.002137  0.002204 \r\n " +
                                                "0.001571  0.001973  0.002274  0.002464  0.002542 \r\n " +
                                                "0.001702  0.002137  0.002464  0.002670  0.002754 \r\n " +
                                                "0.001755  0.002204  0.002542  0.002754  0.002840 \r\n";

            // Act 
            var actualMatrixString = _matrixService.GenerateMatrix(testValues, 4, 5);

            // Assert 
            Assert.AreEqual(expectedMatrixString, actualMatrixString);
        }

        [Test]
        public void GenerateMatrix_ReturnsFiveByFiveMatrix_WhenCIsFourAndNIsThreeHundredAndValidDataFileIsPresent()
        {
            // Arrange 
            var testValues = GetSampleDataValues();
            const string expectedMatrixString = " 0.279525  0.276682  0.268098  0.254212  0.235722 \r\n " +
                                                "0.276682  0.280218  0.277855  0.269717  0.256231 \r\n " +
                                                "0.268098  0.277855  0.281864  0.279912  0.272113 \r\n " +
                                                "0.254212  0.269717  0.279912  0.284270  0.282571 \r\n " +
                                                "0.235722  0.256231  0.272113  0.282571  0.287076 \r\n";

            // Act 
            var actualMatrixString = _matrixService.GenerateMatrix(testValues, 4, 300);

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

        #region Test Data

        private static double[] GetSampleDataValues()
        {
            return new[]
            {
                0.0532925166190, 0.0516683794558, 0.0476902537048, 0.0413647554815, 0.0329319946468, 0.0228458903730, 0.0117255663499,
                0.0002848691074, -0.0107496557757, -0.0207205601037, -0.0291095934808, -0.0355867929757, -0.0400327593088, -0.0425324626267,
                -0.0433433130383, -0.0428436547518, -0.0414704754949, -0.0396559350193, -0.0377718657255, -0.0360894016922, -0.0347581319511,
                -0.0338057726622, -0.0331562347710, -0.0326613150537, -0.0321395844221, -0.0314154438674, -0.0303520243615, -0.0288730505854,
                -0.0269710943103, -0.0247020889074, -0.0221683382988, -0.0194941032678, -0.0167989209294, -0.0141738941893, -0.0116654708982,
                -0.0092696072534, -0.0069371834397, -0.0045893550850, -0.0021395541262, 0.0004824723583, 0.0033096990082, 0.0063245808706,
                0.0094567947090, 0.0125931501389, 0.0155984498560, 0.0183437597007, 0.0207367613912, 0.0227479822934, 0.0244269538671,
                0.0259037390351, 0.0273736491799, 0.0290660317987, 0.0312010571361, 0.0339411199093, 0.0373451150954, 0.0413341820240, 0.0456762500107,
                0.0499941930175, 0.0537986382842, 0.0565425269306, 0.0576905682683, 0.0567938797176, 0.0535586066544, 0.0478977374732, 0.0399573929608,
                0.0301125887781, 0.0189320761710, 0.0071165408008, -0.0045812586322, -0.0154430521652, -0.0248658861965, -0.0324256718159, -0.0379147380590,
                -0.0413487069309, -0.0429429747164, -0.0430635996163, -0.0421613194048, -0.0406996309757, -0.0390882901847, -0.0376321077347,
                -0.0365019105375, -0.0357304140925, -0.0352315418422, -0.0348376892507, -0.0343469046056, -0.0335705876350, -0.0323729887605,
                -0.0306958090514, -0.0285644773394, -0.0260762590915, -0.0233739838004, -0.0206117015332, -0.0179199818522, -0.0153782712296,
                -0.0130000934005, -0.0107339872047, -0.0084797972813, -0.0061165797524, -0.0035359491594, -0.0006734040799, 0.0024695438333 ,
                0.0058178631589, 0.0092326058075, 0.0125365462154, 0.0155513035133, 0.0181386470795, 0.0202373061329, 0.0218868646771, 0.0232323091477,
                0.0245061907917, 0.0259895473719, 0.0279571004212, 0.0306156892329, 0.0340470597148, 0.0381662361324, 0.0427047684789, 0.0472243055701,
                0.0511610209942, 0.0538959056139, 0.0548411570489, 0.0535294860601, 0.0496920049191, 0.0433115623891, 0.0346418991685, 0.0241883546114,
                0.0126520646736, 0.0008454917697, -0.0104080187157, -0.0203753504902, -0.0284999944270, -0.0344607979059, -0.0381948798895, -0.0398825220764,
                -0.0398981124163, -0.0387366637588, -0.0369290523231, -0.0349603630602, -0.0332043766975, -0.0318836681545, -0.0310597084463, -0.0306516829878,
                -0.0304777231067, -0.0303086135536, -0.0299225784838, -0.0291504636407, -0.0279035065323, -0.0261800792068, -0.0240523703396, -0.0216382015496,
                -0.0190659165382, -0.0164412595332, -0.0138240419328, -0.0112196756527, -0.0085868416354, -0.0058585838415, -0.0029708771035, 0.0001090952646,
                0.0033627236262, 0.0067136925645, 0.0100382464007, 0.0131905889139, 0.0160381868482, 0.0184989310801, 0.0205710623413, 0.0223475974053,
                0.0240098945796, 0.0257990472019, 0.0279686525464, 0.0307266917080, 0.0341773293912, 0.0382744073868, 0.0427970215678, 0.0473542734981,
                0.0514211505651, 0.0544018819928, 0.0557119883597, 0.0548662506044, 0.0515582785010, 0.0457181893289, 0.0375381410122, 0.0274606421590,
                0.0161306001246, 0.0043181218207, -0.0071761975996, -0.0176188964397, -0.0264293029904, -0.0332405380905, -0.0379274860024, -0.0405989438295,
                -0.0415570475161, -0.0412322878838, -0.0401059724391, -0.0386333949864, -0.0371800288558, -0.0359800457954, -0.0351220183074, -0.0345615223050,
                -0.0341557152569, -0.0337113402784, -0.0330358892679, -0.0319818258286, -0.0304759014398, -0.0285291299224, -0.0262270495296, -0.0237039867789,
                -0.0211080461740, -0.0185651592910, -0.0161503069103, -0.0138722267002, -0.0116747468710, -0.0094542494044, -0.0070891426876, -0.0044745584019,
                -0.0015542481560, 0.0016579205403, 0.0050723878667, 0.0085364617407, 0.0118633378297, 0.0148722166196, 0.0174313895404, 0.0194949898869,
                0.0211247242987, 0.0224903989583, 0.0238468758762, 0.0254896655679, 0.0276958271861, 0.0306601803750, 0.0344386361539, 0.0389099717140,
                0.0437648370862, 0.0485265254974, 0.0526025444269, 0.0553606189787, 0.0562181174755, 0.0547309890389, 0.0506677590311, 0.0440561063588,
                0.0351935699582, 0.0246198177338, 0.0130539722741, 0.0013063244987, -0.0098220268264, -0.0196362193674, -0.0276266075671, -0.0335181429982,
                -0.0372837483883, -0.0391212925315, -0.0393999330699, -0.0385862402618, -0.0371634811163, -0.0355578064919, -0.0340829603374,
                -0.0329111143947, -0.0320722311735, -0.0314789377153, -0.0309694465250, -0.0303582474589, -0.0294836964458, -0.0282431095839,
                -0.0266094394028, -0.0246278364211, -0.0223949924111, -0.0200276654214, -0.0176289249212, -0.0152606805786, -0.0129291983321,
                -0.0105870179832, -0.0081505561247, -0.0055288407020, -0.0026559964754, 0.0004810274113, 0.0038270910736, 0.0072607840411,
                0.0106145795435, 0.0137097919360, 0.0163991078734, 0.0186070408672, 0.0203583706170, 0.0217864327133, 0.0231169238687, 0.0246279146522,
                0.0265919212252, 0.0292102526873, 0.0325524061918, 0.0365132652223, 0.0407985337079, 0.0449439026415, 0.0483676604927, 0.0504498742521,
                0.0506260804832, 0.0484801083803, 0.0438199527562, 0.0367231070995, 0.0275425743312, 0.0168714132160, 0.0054707201198, -0.0058276853524,
                -0.0162283275276, -0.0250717699528, -0.0319112800062
            };
        }

        #endregion
    }
}