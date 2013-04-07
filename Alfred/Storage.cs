using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Alfred
{
    //@author A0088589B
    class Storage
    {
        private static List<Task> taskList = new List<Task>();
        private static List<string> stringTaskList = new List<string>();

        public static void toStringList()
        {
            stringTaskList.RemoveRange(0, stringTaskList.Count);

            for (int i = 0; i < taskList.Count; i++)
            {
                string currentTask;
                currentTask = taskList[i].setTaskDescription.ToString() + Utility.SPACE_CHAR + taskList[i].setTag.ToString();

                string startDate = assignStartDate(i);

                string startTime = String.Format(Utility.TIME_FORMAT_STORAGE, taskList[i].setStart);

                string endDate = assignEndDate(i);

                string endTime = String.Format(Utility.TIME_FORMAT_STORAGE, taskList[i].setEnd); ;

                isTaskFloating(i, ref startDate, ref startTime, ref endDate, ref endTime);

                currentTask = currentTask + Utility.SPACE_CHAR + startDate + Utility.SPACE_CHAR
                                + startTime + Utility.SPACE_CHAR + endDate + Utility.SPACE_CHAR + endTime;

                stringTaskList.Add(currentTask);
            }
        }

        private static void isTaskFloating(int i, ref string startDate, ref string startTime, ref string endDate, ref string endTime)
        {
            if (getTaskList()[i].setEnd.ToString() == DateTime.MaxValue.ToString())
            {
                endTime = Utility.hyphen;
                endDate = Utility.hyphen;
            }

            if (getTaskList()[i].setStart.ToString() == DateTime.MaxValue.ToString())
            {
                startTime = Utility.hyphen;
                startDate = Utility.hyphen;
            }
        }

        private static string assignEndDate(int i)
        {
            string endDate;
            if (taskList[i].setEnd.Date == DateTime.Now.Date)
            {
                endDate = Utility.DATE_TODAY;
            }

            else if (taskList[i].setEnd.Date == DateTime.Now.Date.AddDays(1))
            {
                endDate = Utility.DATE_TOMORROW;
            }

            else
            {
                endDate = String.Format("{0:dd MMM}", taskList[i].setEnd) + Utility.SPACE_CHAR
                           + String.Format("{0:dd/MM/yy}", taskList[i].setEnd);
            }
            return endDate;
        }

        private static string assignStartDate(int i)
        {
            string startDate;
            if (taskList[i].setStart.Date == DateTime.Now.Date)
            {
                startDate = Utility.DATE_TODAY + Utility.SPACE_CHAR + String.Format("{0:dd MMM}", taskList[i].setStart)
                            + Utility.SPACE_CHAR + String.Format("{0:dd/MM/yy}", taskList[i].setStart);
            }

            else if (taskList[i].setStart.Date == DateTime.Now.Date.AddDays(1))
            {
                startDate = Utility.DATE_TOMORROW + Utility.SPACE_CHAR + String.Format("{0:dd MMM}", taskList[i].setStart)
                            + Utility.SPACE_CHAR + String.Format("{0:dd/MM/yy}", taskList[i].setStart);
            }

            else
            {
                startDate = String.Format("{0:dd MMM}", taskList[i].setStart) + Utility.SPACE_CHAR
                            + String.Format("{0:dd/MM/yy}", taskList[i].setStart);
            }
            return startDate;
        }

        public static List<Task> readFromFile()
        {
            taskList.Clear();
            checkIfFileExists();

            using (StreamReader reader = new StreamReader(Utility.DATA_FILE))
            {
                string number;
                string line;

                number = reader.ReadLine();
                int numberOfTasks = int.Parse(number);

                if (numberOfTasks == 0)
                {
                    return getTaskList();
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

                for (int i = 0; i < numberOfTasks; i++)
                {
                    Task temp = new Task();

                    for (int j = 0; j < Utility.MAX_TASK_FIELDS; j++)
                    {
                        line = reader.ReadLine();

                        switch (j)
                        {
                            case 0:
                                temp.setTaskID = int.Parse(line.ToString());
                                break;

                            case 1:
                                temp.setTaskDescription = line;
                                break;

                            case 2:
                                temp.setCategory = line;
                                break;

                            case 3:
                                DateTime start = DateTime.Parse(line);
                                temp.setStart = start;
                                break;

                            case 4:
                                DateTime end = DateTime.Parse(line);
                                temp.setEnd = end;
                                break;

                            case 5:
                                temp.setTag = line;
                                break;

                            case 6:
                                bool isCompleted = bool.Parse(line);
                                temp.setIsCompleted = isCompleted;
                                break;
                        }
                    }
                    taskList.Add(temp);
                }
            }
            return taskList;
        }

        private static void checkIfFileExists()
        {
            if (!File.Exists(Utility.DATA_FILE))
            {
                using (StreamWriter fileWriter = File.CreateText(Utility.DATA_FILE))
                {
                    fileWriter.WriteLine(Utility.MIN_SIZE);
                }
            }
        }

        //@author A0081050X
        public static List<string> getStringTaskList()
        {
            return stringTaskList;
        }

        public static List<Task> getTaskList()
        {

            return taskList;
        }

        public static void setTaskList(List<Task> newlist)
        {
            taskList = newlist;
        }

        public static void addData(Task newTask)
        {
            Debug.Assert(newTask != null);
            taskList.Add(newTask);
            sortTaskList();

        }

        public static void removeData(int index)
        {
            taskList.RemoveAt(index);
            sortTaskList();
        }

        public static void writeToFile()
        {
            File.WriteAllText(Utility.DATA_FILE, String.Empty);

            using (StreamWriter fileWriter = new StreamWriter(Utility.DATA_FILE, true))
            {

                int numOfTasks = taskList.Count;
                string endDate;
                string endTime;
                string startTime;
                string startDate;

                for (int i = 0; i < numOfTasks; i++)
                {
                    taskList[i].setTaskID = (i + 1);
                }

                fileWriter.WriteLine(numOfTasks);

                for (int i = 0; i < numOfTasks; i++)
                {
                    Task taskToBeWritten = taskList[i];

                    fileWriter.WriteLine(taskToBeWritten.setTaskID);
                    fileWriter.WriteLine(taskToBeWritten.setTaskDescription);
                    fileWriter.WriteLine(taskToBeWritten.setCategory);

                    // set date format to dd/mm/yyyy
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                    endDate = taskToBeWritten.setEnd.ToString("d");
                    startDate = taskToBeWritten.setStart.ToString("d");

                    // set time format to hh:mm:ss tt
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
                    endTime = taskToBeWritten.setEnd.ToString("T");
                    startTime = taskToBeWritten.setStart.ToString("T");

                    fileWriter.WriteLine(startDate + Utility.SPACE_CHAR + startTime);
                    fileWriter.WriteLine(endDate + Utility.SPACE_CHAR + endTime);
                    fileWriter.WriteLine(taskToBeWritten.setTag);
                    fileWriter.WriteLine(taskToBeWritten.setIsCompleted);
                }
                fileWriter.Close();
            }
        }

        public static List<Task> getTaskListShallowcopy()
        {
            List<Task> currtasklist = new List<Task>();

            for (int i = 0; i < Storage.getTaskList().Count; i++)
            {
                currtasklist.Add(Storage.getTaskList()[i].getShallowTask());
            }

            List<Task> shallowcopy = currtasklist.GetRange(0, currtasklist.Count);
            return shallowcopy;
        }

        public static void sortTaskList()
        {
            taskList.Sort(Task.CompareDates);
        }

        //@author A0088589B
        public static void updateStorage()
        {
            Storage.writeToFile();
            Storage.readFromFile();
            Storage.toStringList();
        }
    }
}