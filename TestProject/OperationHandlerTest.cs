using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for OperationHandlerTest and is intended
    ///to contain all OperationHandlerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OperationHandlerTest
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
        ///A test for determineCommand
        ///</summary>
         [TestMethod()]
        //@author A0081050X
        public void determineAddCommandTest_TD()
          {
              UI testui = new UI();
              OperationHandler target = new OperationHandler();
              string input = Utility.TEST_NORMAL_ADDTASK_1;
              OperationHandler.determineCommand(input);
              string expected = Utility.TEST_NORMAL_ADDTASK_1; 
              string actual = Storage.getTaskList()[Storage.getTaskList().Count-1].setTaskDescription+Utility.SPACE_CHAR;
              Assert.AreEqual(expected, actual);
              
          }

         [TestMethod()]
         public void determineAddCommandTest2_TD()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input = "add "+Utility.TEST_NORMAL_ADDTASK_1;
             OperationHandler.determineCommand(input);
             string expected = Utility.TEST_NORMAL_ADDTASK_1;
             string actual = Storage.getTaskList()[Storage.getTaskList().Count - 1].setTaskDescription + Utility.SPACE_CHAR;
             Assert.AreEqual(expected, actual);

         }

         [TestMethod()]
         public void determineAddCommandTest_ST_SD()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input = Utility.TEST_NORMAL_ADDTASK_3;
             OperationHandler.determineCommand(input);
             string expected ="08/10/2012 08:00:00 ";
             string actual = Storage.getTaskList()[Storage.getTaskList().Count - 1].setStart + " ";
             Assert.AreEqual(expected, actual);

         }
         [TestMethod()]
         public void determineAddCommandTest_ET_ED()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input = Utility.TEST_NORMAL_ADDTASK_3;
             OperationHandler.determineCommand(input);
             string expected = "10/10/2012 12:00:00 ";
             string actual = Storage.getTaskList()[Storage.getTaskList().Count - 1].setEnd +" ";
             Assert.AreEqual(expected, actual);

         }


         [TestMethod()]
         public void determineEditCommandTest()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input = Utility.TEST_NORMAL_ADDTASK_1;
             OperationHandler.determineCommand(input);
             string edit = Utility.TEST_NORMAL_ADDTASK_2;
             OperationHandler.determineCommand("edit 1 " + edit);
             string expected = Utility.TEST_NORMAL_ADDTASK_2;
             string actual = Storage.getTaskList()[Storage.getTaskList().Count - 1].setTaskDescription + Utility.SPACE_CHAR;
             Assert.AreEqual(expected, actual);
         }

         [TestMethod()]
         public void determineUndoCommandTest()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input = Utility.TEST_NORMAL_ADDTASK_1;
             OperationHandler.determineCommand(input);
             string edit = Utility.TEST_NORMAL_ADDTASK_2;
             OperationHandler.determineCommand("edit 1 " + edit);
             OperationHandler.determineCommand("undo");
             string expected = Utility.TEST_NORMAL_ADDTASK_1;
             string actual = Storage.getTaskList()[Storage.getTaskList().Count - 1].setTaskDescription + Utility.SPACE_CHAR;
             Assert.AreEqual(expected, actual);
         }

         [TestMethod()]
         public void determineRedoCommandTest()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input = Utility.TEST_NORMAL_ADDTASK_1;
             OperationHandler.determineCommand(input);
             string edit = Utility.TEST_NORMAL_ADDTASK_2;
             OperationHandler.determineCommand("edit 1 " + edit);
             OperationHandler.determineCommand("undo");
             OperationHandler.determineCommand("redo");
             string expected = Utility.TEST_NORMAL_ADDTASK_2;
             string actual = Storage.getTaskList()[Storage.getTaskList().Count - 1].setTaskDescription + Utility.SPACE_CHAR;
             Assert.AreEqual(expected, actual);
         }

         [TestMethod()]
         public void determineSearchCommandTest()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input1 = Utility.TEST_NORMAL_ADDTASK_1;
             string input2 = Utility.TEST_NORMAL_ADDTASK_2;
             string input3 = Utility.TEST_NORMAL_ADDTASK_3;
             string input4 = Utility.TEST_NORMAL_ADDTASK_4;
             string input5 = Utility.TEST_NORMAL_ADDTASK_5;
             OperationHandler.determineCommand(input1);
             OperationHandler.determineCommand(input2);
             OperationHandler.determineCommand(input3);
             OperationHandler.determineCommand(input4);
             OperationHandler.determineCommand(input5);
             
             List<Task> searchedlist = OperationHandler.determineCommand("search swim");    
             int expected = 2;
             int actual =searchedlist.Count ;
             Assert.AreEqual(expected, actual);

             searchedlist = OperationHandler.determineCommand("search go");
             expected = 4;
             actual = searchedlist.Count;
             Assert.AreEqual(expected, actual);
         }
         [TestMethod()]
         public void determineSearchCommandTest2()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input1 = Utility.TEST_NORMAL_ADDTASK_1;
             string input2 = Utility.TEST_NORMAL_ADDTASK_2;
             string input3 = Utility.TEST_NORMAL_ADDTASK_3;
             string input4 = Utility.TEST_NORMAL_ADDTASK_4;
             string input5 = Utility.TEST_NORMAL_ADDTASK_5;
             OperationHandler.determineCommand(input1);
             OperationHandler.determineCommand(input2);
             OperationHandler.determineCommand(input3);
             OperationHandler.determineCommand(input4);
             OperationHandler.determineCommand(input5);
             List<Task> searchedlist = OperationHandler.determineCommand("search 12/12");

             int expected = 1;
             int actual = searchedlist.Count;
             Assert.AreEqual(expected, actual);
         }

         [TestMethod()]
         public void determineCompleteCommandTest()
         {
             UI testui = new UI();
             OperationHandler target = new OperationHandler();
             string input = Utility.TEST_NORMAL_ADDTASK_1;
             OperationHandler.determineCommand(input);
             OperationHandler.determineCommand("complete 1");
             bool expected = true;
             bool actual = Storage.getTaskList()[Storage.getTaskList().Count - 1].setIsCompleted ;
             Assert.AreEqual(expected, actual);

         }

        /// <summary>
        ///A test for extractFirstWord
        ///</summary>
        [TestMethod()]
        public void extractFirstWordTest()
        {
            string input = "add item"; 
            string expected = "add"; 
            string actual;
            actual = OperationHandler.extractFirstWord(input);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
