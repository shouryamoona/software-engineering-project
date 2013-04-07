using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for StorageTest and is intended
    ///to contain all StorageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StorageTest
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
        ///A test for addData
        ///</summary>
        [TestMethod()]
        public void addDataTest()
        {
            Task newTask = new Task();
            newTask.setTaskDescription = Utility.TEST_NORMAL_ADDTASK_1;
            Storage.addData(newTask);
            int expected = 1;
            int actual = Storage.getTaskList().Count;

            Assert.AreEqual(expected, actual);
            
        }


        /// <summary>
        ///A test for removeData
        ///</summary>
        [TestMethod()]
        //@author A0081050X
        public void removeDataTest()
        {
            int testnum = 100;
            int testnum2 = 50;
            for (int i = 0; i < testnum; i++)
            {
                Task newtask = new Task();
                Storage.addData(newtask);
            }
            for (int i = 0; i < testnum2; i++)
            {
                int index = 0; 
                Storage.removeData(index);
            }
            
            int expected = 50;
            int actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for toStringList
        ///</summary>
        [TestMethod()]
        public void toStringListTest()
        {
            Add adder = new Add();
            adder.addTask(Utility.TEST_NORMAL_ADDTASK_3);
            Storage.toStringList();
            string actual = Storage.getStringTaskList()[0];
            string expected = Utility.TEST_STORAGE_TASK_EXPECTED;
            Assert.AreEqual(expected, actual);
        }


    }
}
