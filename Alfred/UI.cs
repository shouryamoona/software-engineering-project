using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

//@author A0088589B
namespace Alfred
{
    public partial class UI : Form
    {
        static bool isExpanded = false;
        public static Label statusMessageLabel;
        List<string> commandList = new List<string>();
        Stack<string> previousCommand = new Stack<string>();
        Stack<string> nextCommand = new Stack<string>();
        public static string StatusText { set { statusMessageLabel.Text = value; } }

        public UI()
        {
            InitializeComponent();
            statusMessageLabel = alfredSays;
            UI.StatusText = Utility.STATUS_INITIAL;
            updateListView(Storage.getTaskList());
        }

        private void updateListView(List<Task> taskList)
        {
            string[] arr = new string[5];
            ListViewItem itm;

            listView.Items.Clear();

            for (int i = 0; i < taskList.Count; i++)
            {
                arr[0] = taskList[i].setTaskID.ToString();
                arr[1] = taskList[i].setTaskDescription;
                arr[2] = getStart(i, taskList);
                arr[3] = getEnd(i, taskList);
                arr[4] = taskList[i].setTag;
                itm = new ListViewItem(arr);
                listView.Items.Add(itm);
                listView.Items[i].Font = new Font(listView.Items[i].Font, FontStyle.Regular);

                if (taskList[i].setIsCompleted == true)
                {
                    listView.Items[i].Font = new Font(listView.Items[i].Font, FontStyle.Strikeout);
                }
            }
        }

        private string getEnd(int index, List<Task> taskList)
        {
            string end;
            string endDate;
            string endTime;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            endDate = getDate(index, taskList, taskList[index].setEnd.Date);
            endTime = taskList[index].setEnd.ToString("t");

            if (taskList[index].setEnd.ToString() == DateTime.MaxValue.ToString() || taskList[index].setEnd == DateTime.Parse(Utility.MAX_ALT_TIME))
            {
                end = "-";
            }

            else
            {
                end = endDate + " @ " + endTime;
            }
            return end;
        }

        private string getStart(int index, List<Task> taskList)
        {
            string start;
            string startDate;
            string startTime;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            startDate = getDate(index, taskList,taskList[index].setStart.Date);

            if (taskList[index].setStart.ToString() == DateTime.MaxValue.ToString() || taskList[index].setStart == DateTime.Parse(Utility.MAX_ALT_TIME))
            {
                start = Utility.hyphen;
            }

            else
            {
                startTime = taskList[index].setStart.ToString("t");
                start = startDate + " @ " + startTime;
            }
            return start;
        }

        private static string getDate(int index, List<Task> taskList, DateTime date)
        {
            string dateString;


            if (date == DateTime.Now.Date)
            {
                dateString = Utility.DATE_TODAY;
            }

            else if (date == DateTime.Now.Date.AddDays(1))
            {
                dateString = Utility.DATE_TOMORROW;
            }

            else
            {
                dateString = String.Format("{0:dd MMM}", date);
            }
            return dateString;
        }

        private void expand_contract_Click(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                collapseView();
            }

            else
            {
                expandView();
            }
        }

        private void expandView()
        {
            this.Size = new System.Drawing.Size(700, 489);
            expandContract.Image = Alfred.Properties.Resources.collapse;
            isExpanded = true;
        }

        private void collapseView()
        {
            this.Size = new System.Drawing.Size(700, 142);
            expandContract.Image = Alfred.Properties.Resources.expand;
            isExpanded = false;
        }

        private void intelliBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S" && isExpanded)
            {
                e.SuppressKeyPress = true;
                collapseView();
            }

            else if (e.Control && e.KeyCode.ToString() == "S" && !isExpanded)
            {
                e.SuppressKeyPress = true;
                expandView();
            }

            else if (e.KeyCode == Keys.Enter)
            {
                string input = intelliBar.Text;

                try
                {
                    if (input != Utility.EMPTY_STRING && input != previousCommand.Peek())
                    {
                        previousCommand.Push(intelliBar.Text);
                    }
                }

                catch
                {
                    previousCommand.Push(intelliBar.Text);
                }

                e.SuppressKeyPress = true;
                List<Task> taskList = OperationHandler.determineCommand(input);
                intelliBar.Clear();
                updateListView(taskList);
            }

            else if (e.Control && e.KeyCode.ToString() == "M")
            {
                minimizeToSysTray();
                e.SuppressKeyPress = true;
            }

            else if (e.KeyCode == Keys.Up)
            {
                if (previousCommand.Count != 0)
                {
                    try
                    {
                        while (intelliBar.Text == previousCommand.Peek())
                        {
                            nextCommand.Push(previousCommand.Pop());
                        }

                        nextCommand.Push(intelliBar.Text = previousCommand.Pop());
                    }
                    catch { }
                    intelliBar.SelectionStart = intelliBar.Text.Length;
                }
            }

            else if (e.KeyCode == Keys.Down)
            {
                if (nextCommand.Count != 0)
                {
                    try
                    {
                        while (intelliBar.Text == nextCommand.Peek())
                        {
                            previousCommand.Push(nextCommand.Pop());
                        }

                        previousCommand.Push(intelliBar.Text = nextCommand.Pop());
                    }
                    catch { }
                    intelliBar.SelectionStart = intelliBar.Text.Length;
                }
            }
        }

        private void minimizeToSysTray()
        {
            Hide();
            sysTray.Visible = true;
            sysTray.ShowBalloonTip(1000);
        }

        private void UI_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                minimizeToSysTray();
            }
        }

        private void sysTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            maximizeFromSysTray();
        }

        private void maximizeFromSysTray()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            sysTray.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maximizeFromSysTray();
        }

        private void expand_contract_MouseEnter(object sender, EventArgs e)
        {
            expandContract.BorderStyle = BorderStyle.Fixed3D;
        }

        private void expand_contract_MouseLeave(object sender, EventArgs e)
        {
            expandContract.BorderStyle = BorderStyle.None;
        }

        private void intelliBar_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(intelliBar.Text, Utility.COMMAND_ADD, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                statusMessageLabel.Text = Utility.COMMAND_ADD_FORMAT;
            }

            else if (intelliBar.Text.Length != 0 && OperationHandler.extractFirstWord(intelliBar.Text.ToLower() + Utility.SPACE_CHAR) == Utility.COMMAND_SEARCH)
            {
                statusMessageLabel.Text = Utility.COMMAND_SEARCH_FORMAT;
                List<Task> searchResults = OperationHandler.determineCommand(intelliBar.Text);
                updateListView(searchResults);
            }

            else if (string.Equals(intelliBar.Text, Utility.COMMAND_DELETE, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                statusMessageLabel.Text = Utility.COMMAND_DELETE_FORMAT;
            }

            else if (string.Equals(intelliBar.Text, Utility.COMMAND_EDIT, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                statusMessageLabel.Text = Utility.COMMAND_EDIT_FORMAT;
            }

            else if (string.Equals(intelliBar.Text, Utility.COMMAND_CLEAR, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                statusMessageLabel.Text = Utility.COMMAND_CLEAR_FORMAT;
            }

            else if (string.Equals(intelliBar.Text, Utility.COMMAND_COMPLETE, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                statusMessageLabel.Text = Utility.COMMAND_COMPLETE_FORMAT;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo help = new ProcessStartInfo();
                help.FileName = Utility.HELP_FILE;
                Process.Start(help);
            }

            catch
            {
                MessageBox.Show(Utility.ERROR_NO_HELP_FILE);
            }
        }
    }
}
