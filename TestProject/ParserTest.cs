using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ParserTest and is intended
    ///to contain all ParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParserTest
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
        ///A test for addCorrectSuffix
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        //@author A00981050X
        public void addCorrectSuffixTest()
        {
            string input = "new task"; 
            string expected = "add new task -"; 
            string actual;
            actual = Parser_Accessor.addCorrectSuffix(input);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for combineDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void combineDateTimeTest()
        {
            Parser_Accessor target = new Parser_Accessor(); 
            string input = Utility.TEST_PARSER_TASK_ALL; 
            target.combineDateTime(input);
            string expected=Utility.TEST_PARSER_START;
            string actual =target.start+" ";
            Assert.AreEqual(expected, actual);
            
            expected = Utility.TEST_PARSER_END;
            actual = target.end + " ";
            Assert.AreEqual(expected, actual);
           
            
        }


        /// <summary>
        ///A test for indexBeforeNextHyphen
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void indexBeforeNextHyphenTest()
        {
            string input = Utility.TEST_PARSER_TASK_ALL; 
            int startPosition = 0; 
            int endPosition = 0; 
            int expected = 15; 
            int actual;
            actual = Parser_Accessor.indexBeforeNextHyphen(input, startPosition, endPosition);
            Assert.AreEqual(expected, actual);
            
        }

        

        /// <summary>
        ///A test for isInvalidDateTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        //@author A0088589B
        public void isInvalidDateTimeTest()
        {
            string dateTime = Utility.TEST_PARSER_START; 
            bool expected = false; 
            bool actual;
            actual = Parser_Accessor.isInvalidDateTime(dateTime);
            Assert.AreEqual(expected, actual);

            dateTime = Utility.TEST_PARSERTAG;
            expected = true;
            actual = Parser_Accessor.isInvalidDateTime(dateTime);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for isStartDateLessThanEndDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void isStartDateLessThanEndDateTest()
        {
            string startDate = Utility.TEST_PARSER_START; 
            string endDate = Utility.TEST_PARSER_END; 
            bool expected = true; 
            bool actual;
            actual = Parser_Accessor.isStartDateLessThanEndDate(startDate, endDate);
            Assert.AreEqual(expected, actual);

            startDate = Utility.TEST_PARSER_END;
            endDate = Utility.TEST_PARSER_START;
            expected = false;
            actual = Parser_Accessor.isStartDateLessThanEndDate(startDate, endDate);
            Assert.AreEqual(expected, actual);
          
        }

        /// <summary>
        ///A test for parseEndDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        //@author A0091525H
        public void parseEndDateTest()
        {
            Parser_Accessor target = new Parser_Accessor();
            string input = Utility.TEST_PARSER_TASK_ALL;
            string expected = Utility.TEST_PARSER_ENDDATE;
            string actual;
            actual = target.parseEndDate(input);
            Assert.AreEqual(expected, actual);
          
        }

        /// <summary>
        ///A test for parseEndTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void parseEndTimeTest()
        {
            Parser_Accessor target = new Parser_Accessor(); 
            string input = Utility.TEST_PARSER_TASK_ALL;
            string expected = Utility.TEST_PARSER_ENDTIME;
            string actual;
            actual = target.parseEndTime(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for parseStartDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void parseStartDateTest()
        {
            Parser_Accessor target = new Parser_Accessor(); 
            string input = Utility.TEST_PARSER_TASK_ALL; 
            string expected = Utility.TEST_PARSER_STARTDATE;
            string actual;
            actual = target.parseStartDate(input);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for parseStartTime
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void parseStartTimeTest()
        {
            Parser_Accessor target = new Parser_Accessor(); 
            string input = Utility.TEST_PARSER_TASK_ALL;
            string expected = Utility.TEST_PARSER_STARTTIME;
            string actual;
            actual = target.parseStartTime(input);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for parseTag
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]

        //@author A0088589B
        public void parseTagTest()
        {
            Parser_Accessor target = new Parser_Accessor(); 
            string input = Utility.TEST_PARSER_TASK_ALL; 
            string expected = Utility.TEST_PARSERTAG; 
            string actual;
            actual = target.parseTag(input);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for parseTaskDescription
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void parseTaskDescriptionTest()
        {
            Parser_Accessor target = new Parser_Accessor(); 
            string input = Utility.TEST_PARSER_TASK_ALL; 
            string expected = Utility.TEST_PARSER_TASK_DESCRIPTION; 
            string actual;
            actual = target.parseTaskDescription(input);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for returnTask
        ///</summary>
        [TestMethod()]
        public void returnTaskTest()
        {
            Parser target = new Parser();
            string input = Utility.TEST_PARSER_TASK_ALL; 
            Task parsedtask = new Task();
            parsedtask = target.returnTask(input);
            
            string expected=Utility.TEST_PARSER_TASK_DESCRIPTION;
            string actual=parsedtask.setTaskDescription;
            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_PARSER_START;
            actual = parsedtask.setStart+" ";
            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_PARSER_END;
            actual = parsedtask.setEnd + " ";
            Assert.AreEqual(expected, actual);

            expected = Utility.TEST_PARSERTAG;
            actual = parsedtask.setTag;
            Assert.AreEqual(expected, actual);
            

            
        }

        /// <summary>
        ///A test for setEndAndStartPosition
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void setEndAndStartPositionTest()
        {
            Parser_Accessor target = new Parser_Accessor(); 
            string input = Utility.TEST_PARSER_TASK_ALL;
            int startPosition = 15; //st
            int startPositionExpected = 18; 
            int endPosition = 0; 
            int endPositionExpected = 23; 
            int expected = 23;
            int actual;
            actual = target.setEndAndStartPosition(input, ref startPosition, ref endPosition);
            Assert.AreEqual(startPositionExpected, startPosition);
            Assert.AreEqual(endPositionExpected, endPosition);
            Assert.AreEqual(expected, actual);
            
        }

     
    }
}
