using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for TaskTest and is intended
    ///to contain all TaskTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TaskTest
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
        ///A test for CompareDates
        ///</summary>
        [TestMethod()]
        //@author A0088653R
        public void CompareDatesTest()
        {
            Task x = new Task(); 
            Task y = new Task();
            Parser target = new Parser();
            x = target.returnTask(Utility.TEST_TASK_X);
            y = target.returnTask(Utility.TEST_TASK_Y);
            
            int expected = 0; 
            int actual;
            actual = Task.CompareDates(x, y);
            Assert.AreEqual(expected, actual);
           
        }

    }
}
