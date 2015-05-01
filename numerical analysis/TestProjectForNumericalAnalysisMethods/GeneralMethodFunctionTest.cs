using numerical_analysis.Method_classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProjectForNumericalAnalysisMethods
{


    /// <summary>
    ///This is a test class for GeneralMethodFunctionTest and is intended
    ///to contain all GeneralMethodFunctionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GeneralMethodFunctionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for matrixDeterminantByGauss
        ///</summary>
        [TestMethod()]
        [DeploymentItem("numerical analysis.exe")]
        public void matrixDeterminantByGaussTest()
        {

            double[,] param = new double[2,3]
            {
            { 1, 0, 1 },
            { 2, 4, 6 }
            };
            GeneralMethodFunction_Accessor target = new GeneralMethodFunction_Accessor(param);


            // test case 1
            double[,] matrix = new double[3,3]{
            { 1, 2, 3 },
            { 1, 0, 1 },
            { 2, 4, 6 }
            };
            double expected = 0;
            double actual;
            actual = target.matrixDeterminantByGauss(matrix);
            Assert.AreEqual(expected, actual);



            // test case 2
            matrix = new double[3, 3]{
            { 1, 0, 2 },
            { -3, 4, 6 },
            { -1, -2, 3 }
            };
            expected = 44;
            actual = target.matrixDeterminantByGauss(matrix);
            Assert.AreEqual(expected, actual);



            // test case 2
            matrix = new double[3,3]{
            { 1, 0, 2 },
            { -3, 4, 6 },
            { -1, -2, 3 }
            };
            expected = 44;
            actual = target.matrixDeterminantByGauss(matrix);
            Assert.AreEqual(expected, actual);



            // test case 3
            matrix = new double[3,6]{
            { 5, 0, -1, 3, 8, 2 },
            { 2, 1, 4, 8, 9, 0 },
            { 7, 2, 4, 8, 2, 1 }
            };

            expected = -17;
            actual = target.matrixDeterminantByGauss(matrix);
            Assert.AreEqual(expected, actual);




            // test case 4
            matrix = new double[5, 3]{
            { 3, 2, 1 },
            { 0, 4, 4 },
            { -2, 4, -1 },
            { 3, 4, 1 },
            { 5, 3, -2 }
            };
            expected = -68;
            actual = target.matrixDeterminantByGauss(matrix);
            Assert.AreEqual(expected, actual);
        }
    }
}
