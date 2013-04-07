using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for EditTest and is intended
    ///to contain all EditTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EditTest
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
        ///A test for editing task description in a Task.
        ///Task description should be same as description added.
        ///Other details should be same.
        ///</summary>
        [TestMethod()]
        //@author A0091525H
        public void EditTaskDescriptionTest()
        {
            
            Add adder = new Add();
            Edit target = new Edit();

            adder.addTask(Utility.TEST_EDIT_TASK_TASK);
            target.editTask(Utility.TEST_EDIT_TASK_TASK_DESCRIPTION);

            string expected = Utility.TEST_EDITED_TASK_DESCRIPTION;
            string actual=Storage.getTaskList()[0].setTaskDescription;
           
            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_START;
            actual = Storage.getTaskList()[0].setStart+" ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_END;
            actual = Storage.getTaskList()[0].setEnd + " ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TAG;
            actual = Storage.getTaskList()[0].setTag;

            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for editing start time in a Task.
        ///Start time should be edited.
        ///Other details should be same.
        ///</summary>
        [TestMethod()]
        public void EditStartTimeTest()
        {

            Add adder = new Add();
            Edit target = new Edit(); 

            adder.addTask(Utility.TEST_EDIT_TASK_TASK);
            target.editTask(Utility.TEST_EDIT_TASK_ST);

            string expected = Utility.TEST_EDITED_TASK_ST;
            string actual = Storage.getTaskList()[0].setStart+" ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TASK_DESCRIPTION;
            actual = Storage.getTaskList()[0].setTaskDescription;

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_END;
            actual = Storage.getTaskList()[0].setEnd + " ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TAG;
            actual = Storage.getTaskList()[0].setTag;

            Assert.AreEqual(expected, actual);

        }
        /// <summary>
        ///A test for editing start date in a Task.
        ///Start date should be edited.
        ///Other details should be same.
        ///</summary>
        [TestMethod()]
        public void EditStartDateTest()
        {

            Add adder = new Add();
            Edit target = new Edit();

            adder.addTask(Utility.TEST_EDIT_TASK_TASK);
            target.editTask(Utility.TEST_EDIT_TASK_SD);

            string expected = Utility.TEST_EDITED_TASK_SD;
            string actual = Storage.getTaskList()[0].setStart+" ";
           
            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TASK_DESCRIPTION;
            actual = Storage.getTaskList()[0].setTaskDescription;

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_END;
            actual = Storage.getTaskList()[0].setEnd + " ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TAG;
            actual = Storage.getTaskList()[0].setTag;

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for editing end time in a Task.
        ///End time should be edited.
        ///Other details should be same.
        ///</summary>
        [TestMethod()]
        //@author A0088589B
        public void EditEndTimeTest()
        {

            Add adder = new Add();
            Edit target = new Edit();

            adder.addTask(Utility.TEST_EDIT_TASK_TASK);
            target.editTask(Utility.TEST_EDIT_TASK_ET);

            string expected = Utility.TEST_EDITED_TASK_ET;
            string actual = Storage.getTaskList()[0].setEnd + " ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TASK_DESCRIPTION;
            actual = Storage.getTaskList()[0].setTaskDescription;

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_START;
            actual = Storage.getTaskList()[0].setStart + " ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TAG;
            actual = Storage.getTaskList()[0].setTag;

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for editing end date in a Task.
        ///End date should be edited.
        ///Other details should be same.
        ///</summary>
        [TestMethod()]
        public void EditEndDateTest()
        {

            Add adder = new Add();
            Edit target = new Edit();

            adder.addTask(Utility.TEST_EDIT_TASK_TASK);
            target.editTask(Utility.TEST_EDIT_TASK_ET);

            string expected = Utility.TEST_EDITED_TASK_ET;
            string actual = Storage.getTaskList()[0].setEnd + " ";

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TASK_DESCRIPTION;
            actual = Storage.getTaskList()[0].setTaskDescription;

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_START;
            actual = Storage.getTaskList()[0].setStart + " " ;

            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_EDIT_TASK_INITIAL_TAG;
            actual = Storage.getTaskList()[0].setTag;

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for getIndex
        ///Checks when no task is added and user tries to edit
        ///function should return an invalid number, -1
        ///</summary>
        [TestMethod()]
        public void getIndexTest()
        {
            Edit target = new Edit(); 
            string input = Utility.TEST_EDIT_TASK_TASK_DESCRIPTION; 
            int expected = Utility.TASK_OVERFLOW; 
            int actual;
            actual = target.getIndex(input);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for getIndex
        ///Checks when there is a task and user tries to edit
        ///</summary>
        [TestMethod()]
        public void getIndexTest2()
        {
            Add adder=new Add();
            adder.addTask(Utility.TEST_EDIT_TASK_TASK);
            Edit target = new Edit();
            string input = Utility.TEST_EDIT_TASK_TASK_DESCRIPTION;
            int expected = 1; 
            int actual;
            actual = target.getIndex(input);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
