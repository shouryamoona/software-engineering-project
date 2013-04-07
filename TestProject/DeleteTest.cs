using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for DeleteTest and is intended
    ///to contain all DeleteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DeleteTest
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
        ///A test for deleteTask
        ///Checks if task is deleted
        ///</summary>
        [TestMethod()]
        //@author A0088653R
        public void deleteCorrectTaskTest()
        {
            Delete target = new Delete();
            Add adder = new Add();
            adder.addTask(Utility.TEST_NORMAL_ADDTASK_1);
            adder.addTask(Utility.TEST_NORMAL_ADDTASK_2);
            adder.addTask(Utility.TEST_NORMAL_ADDTASK_3);


            target.deleteTask(Utility.TEST_DELETE_TASK_3);//Task 1:"Go swimming" should be deleted
            string expected = Utility.TEST_NORMAL_ADDTASK_1;
            string actual = Storage.getTaskList()[1].setTaskDescription+Utility.SPACE_CHAR;
            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_DELETE_TASK_3_EXPECTED_TD; ;
            actual = Storage.getTaskList()[0].setTaskDescription+Utility.SPACE_CHAR;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getIndex
        ///Should return value of number after user delete input ie "delete 1"
        ///</summary>
        [TestMethod()]
        public void getIndexTest()
        {
            Delete target = new Delete(); 
            string input = Utility.TEST_DELETE_TASK_1;
            int actual = target.getIndex(input);
            int expected = 1; 
           
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test to delete all tasks
        ///Storage should have nothing inside
        ///</summary>
        [TestMethod()]
        public void deleteAllTaskTest()
        {
            Delete target = new Delete(); 
           
            int expected = 0; 
            int actual;
            Storage.getTaskList().Clear();
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
           
        }
    }
}
