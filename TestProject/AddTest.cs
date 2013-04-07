using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    /// <summary>
    ///This is a test class for AddTest and is intended
    ///to contain all AddTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AddTest
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
        #endregion
    
        /// <summary>
        ///A functional blackbox testing for addTask.
        ///Check if number of tasks are added correctly.
        ///</summary>
        [TestMethod()]

        //@author A0081050X
        public void addTaskNormalTest()
        {
            Add target = new Add();

            int expected = 18; // number of successful tasks
            int actual;

            target.addTask(Utility.TEST_NORMAL_ADDTASK_NO_DETAILS);
            expected = 1;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ST);
            expected = 2;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ST_ET);
            expected = 3;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ST_ET_SD);
            expected = 4;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ST_ET_ED);
            expected = 5;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ST_SD);
            expected = 6;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ST_SD_ED);
            expected = 7;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ST_ED);
            expected = 8;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ET);
            expected = 9;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ET_SD);
            expected = 10;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ET_SD_ED);
            expected = 11;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ET_ED);
            expected = 12;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_SD);
            expected = 13;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_SD_ED);
            expected = 14;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ED);
            expected = 15;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ALL_TIME);
            expected = 16;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_ALL_TIME_T);
            expected = 17;
            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_T);
            expected = 18;
            actual = Storage.getTaskList().Count;

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        //Tests adding tasks with wierd or uncommon inputs
        //Storage should contain all tasks added 
        ///</summary>
        [TestMethod()]
        public void addTaskWierdTest()
        {
            Add target = new Add();

            int expected = 3; // Number of successful tasks
            int actual;

            target.addTask(Utility.TEST_WIERD_ADDTASK_MULTIPLE_ST);
            target.addTask(Utility.TEST_WIERD_ADDTASK_ET_BEFORE_ST_SAME_DATE);
            target.addTask(Utility.TEST_WIERD_ADDTASK_MIXED_COMMANDS_ALL_TIME_T);

            actual = Storage.getTaskList().Count;

            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        //Tests adding tasks with invalid inputs
        //Storage should contain no tasks. 
        ///</summary>

        [TestMethod()]
        public void addTaskInvalidTest()
        {
            Add target = new Add(); 

            int expected = 0; // 0 as all invalid tasks should fail
            int actual;

            target.addTask(Utility.TEST_INVALID_ADDTASK_ET_BEFORE_ST);
            target.addTask(Utility.TEST_INVALID_ADDTASK_ED_BEFORE_SD);
            target.addTask(Utility.TEST_INVALID_ST_ADDTASK_ALL_TIME_T);
            target.addTask(Utility.TEST_INVALID_ET_ADDTASK_ALL_TIME_T);
            target.addTask(Utility.TEST_INVALID_SD_ADDTASK_ALL_TIME_T);
            target.addTask(Utility.TEST_INVALID_ED_ADDTASK_ALL_TIME_T);

            actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);


        }
        [TestMethod()]
        public void addDiffTaskDescriptionsTest()
        {
            Add target = new Add(); 
            
            //adding 5 different Tasks
            target.addTask(Utility.TEST_NORMAL_ADDTASK_1);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_2);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_3);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_4);
            target.addTask(Utility.TEST_NORMAL_ADDTASK_5);

            int expected = 5;
            int actual = Storage.getTaskList().Count;
            Assert.AreEqual(expected, actual);

            string actualtaskdes = Storage.getTaskList()[4].setTaskDescription+Utility.SPACE_CHAR;
            string expectedtaskdes = Utility.TEST_NORMAL_ADDTASK_5;//have to take auto sort into consideration
            Assert.AreEqual(expectedtaskdes, actualtaskdes);


        }
    }
}
