using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for UndoRedoTest and is intended
    ///to contain all UndoRedoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UndoRedoTest
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
        ///A test for redo
        ///</summary>
        [TestMethod()]
        //@author A0081050X
        public void redoTest()
        {
            UndoRedo target = new UndoRedo();

            OperationHandler.determineCommand(Utility.TEST_UNDOREDO_TASK);
            
            target.undo();

            
            target.redo();
            int actual = Storage.getTaskList().Count;
            int expected = 1;
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for undo
        ///</summary>
        [TestMethod()]
        public void undoAddTest()
        {
            UndoRedo target = new UndoRedo();

            OperationHandler.determineCommand(Utility.TEST_UNDOREDO_TASK);
            
            target.undo();
            int actual = Storage.getTaskList().Count;
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void undoDeleteTest()
        {
            UndoRedo target = new UndoRedo();
            UI newui = new UI();

            OperationHandler.determineCommand(Utility.TEST_UNDOREDO_TASK);
            OperationHandler.determineCommand(Utility.TEST_DELETE_TASK_1);
  
            target.undo();
            int actual = Storage.getTaskList().Count;
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void undoEditTest()
        {
            UndoRedo target = new UndoRedo();
            UI newui = new UI();

            OperationHandler.determineCommand(Utility.TEST_UNDOREDO_TASK);
            OperationHandler.determineCommand(Utility.TEST_EDIT_TASK_TASK_DESCRIPTION);

            target.undo();
            string actual = Storage.getTaskList()[0].setTaskDescription;
            string expected = Utility.TEST_UNDOREDO_TASK;
            Assert.AreEqual(expected, actual);

            target.redo();
            actual = Storage.getTaskList()[0].setTaskDescription;
            expected = Utility.TEST_EDITED_TASK_DESCRIPTION;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void undoCompleteTest()
        {
            UndoRedo target = new UndoRedo();
            UI newui = new UI();

            OperationHandler.determineCommand(Utility.TEST_NORMAL_ADDTASK_1);
            OperationHandler.determineCommand(Utility.TEST_UNDOREDO_COMPLETE);

            target.undo();
            bool actual = Storage.getTaskList()[0].setIsCompleted;
            bool expected = false;
            Assert.AreEqual(expected, actual);

            target.redo();
            actual = Storage.getTaskList()[0].setIsCompleted;
            expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
