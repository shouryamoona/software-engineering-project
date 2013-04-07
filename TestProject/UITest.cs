using Alfred;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for UITest and is intended
    ///to contain all UITest Unit Tests
    ///</summary>
    [TestClass()]
    public class UITest
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
        ///A test for UI Constructor
        ///</summary>
      /*  [TestMethod()]
        public void UIConstructorTest()
        {
            UI target = new UI();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void DisposeTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            bool disposing = false; // TODO: Initialize to an appropriate value
            target.Dispose(disposing);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void InitializeComponentTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UI_KeyPress
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void UI_KeyPressTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyPressEventArgs e = null; // TODO: Initialize to an appropriate value
            target.UI_KeyPress(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UI_Load
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void UI_LoadTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.UI_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UI_Resize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void UI_ResizeTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.UI_Resize(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for displayTaskDescriptionsColumn
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void displayTaskDescriptionsColumnTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            List<Task_Accessor> taskList = null; // TODO: Initialize to an appropriate value
            target.displayTaskDescriptionsColumn(taskList);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for displayTaskEndDatesColumn
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void displayTaskEndDatesColumnTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            List<Task_Accessor> taskList = null; // TODO: Initialize to an appropriate value
            target.displayTaskEndDatesColumn(taskList);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for displayTaskStartDatesColumn
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void displayTaskStartDatesColumnTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            List<Task_Accessor> taskList = null; // TODO: Initialize to an appropriate value
            target.displayTaskStartDatesColumn(taskList);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for displayTaskTag
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void displayTaskTagTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            List<Task_Accessor> taskList = null; // TODO: Initialize to an appropriate value
            target.displayTaskTag(taskList);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for exitToolStripMenuItem_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void exitToolStripMenuItem_ClickTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.exitToolStripMenuItem_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for expand_contract_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void expand_contract_ClickTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.expand_contract_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for expand_contract_MouseEnter
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void expand_contract_MouseEnterTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.expand_contract_MouseEnter(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for expand_contract_MouseHover
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void expand_contract_MouseHoverTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.expand_contract_MouseHover(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for expand_contract_MouseLeave
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void expand_contract_MouseLeaveTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.expand_contract_MouseLeave(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for getEndDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void getEndDateTest()
        {
            int index = 0; // TODO: Initialize to an appropriate value
            List<Task_Accessor> taskList = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UI_Accessor.getEndDate(index, taskList);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getStartDate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void getStartDateTest()
        {
            int index = 0; // TODO: Initialize to an appropriate value
            List<Task_Accessor> taskList = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UI_Accessor.getStartDate(index, taskList);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for intelliBar_KeyDown
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void intelliBar_KeyDownTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            KeyEventArgs e = null; // TODO: Initialize to an appropriate value
            target.intelliBar_KeyDown(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for intelliBar_TextChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void intelliBar_TextChangedTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.intelliBar_TextChanged(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for maximizeFromSysTray
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void maximizeFromSysTrayTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            target.maximizeFromSysTray();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for maximizeToolStripMenuItem_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void maximizeToolStripMenuItem_ClickTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.maximizeToolStripMenuItem_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for minimizeToSysTray
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void minimizeToSysTrayTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            target.minimizeToSysTray();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for panel1_Paint
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void panel1_PaintTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            PaintEventArgs e = null; // TODO: Initialize to an appropriate value
            target.panel1_Paint(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for sysTray_MouseDoubleClick
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Alfred.exe")]
        public void sysTray_MouseDoubleClickTest()
        {
            UI_Accessor target = new UI_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            MouseEventArgs e = null; // TODO: Initialize to an appropriate value
            target.sysTray_MouseDoubleClick(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StatusText
        ///</summary>
        [TestMethod()]
        public void StatusTextTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            UI.StatusText = expected;
            Assert.Inconclusive("Write-only properties cannot be verified.");
        }*/
    }
}
