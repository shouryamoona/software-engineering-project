using System;
using System.Linq;
using log4net;
namespace Alfred
{
    //@author A0091525H
    class Edit
    {
        private string userInput;
        ILog log = LogManager.GetLogger(typeof(Edit));

        public int getIndex(string input)
        {
            int index;
            input += "  ";
            index = input.IndexOf(Utility.SPACE_CHAR);
            input = input.Substring(index).Trim();
            int secondIndex = input.IndexOf(Utility.SPACE_CHAR);
            userInput = input.Substring(secondIndex + 1);
            input = input.Substring(0, secondIndex + 1).Trim();

            try
            {
                index = int.Parse(input);
                if (index > Storage.getTaskList().Count())
                {
                    return Utility.TASK_OVERFLOW;
                }

                return index;
            }

            catch
            {
                return Utility.INVALID_INDEX;
            }
        }

        public string editTask(string input)
        {
            log4net.Config.XmlConfigurator.Configure();
            int taskID = getIndex(input);

            if (taskID == Utility.INVALID_INDEX)
            {
                log.Warn(Utility.LOG_INVALID_TASK_DATA_PROMPT);
                return Utility.ERROR_INVALID_EDIT_FORMAT;
            }

            else return mergeTask(taskID);
        }

        private string mergeTask(int taskID)
        {
            Parser parseTask = new Parser();
            Task editedTask = new Task();

            if (taskID > 0 && taskID <= Storage.getTaskList().Count)
            {
                log.Warn(Utility.LOG_PARSING_BEGINS);

                appendNonExistingFields(taskID, parseTask);             
                editedTask = parseTask.returnTask(userInput.TrimStart());
                mergeTaskDescription(taskID, editedTask);
                mergeTaskTag(taskID, editedTask);

                if (editedTask.setStart > editedTask.setEnd 
                    || editedTask.setEnd == DateTime.MinValue 
                    || editedTask.setStart == DateTime.MinValue
                    || editedTask.setEnd == DateTime.MaxValue
                    || editedTask.setStart == DateTime.MaxValue 
                    || editedTask.setEnd == DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE) 
                    || editedTask.setStart == DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE))
                {
                    return Utility.ERROR_INVALID_DATETIME;
                }
                else
                {
                    Storage.getTaskList()[taskID - 1] = editedTask;
                    Storage.updateStorage();
                    return Utility.STATUS_TASK_EDITED;
                }
            }
            else
            {
                return Utility.ERROR_INVALID_TASKNO;
            }
        }

        private static void mergeTaskTag(int taskID, Task editedTask)
        {
            if (editedTask.setTag == Utility.EMPTY_STRING && Storage.getTaskList()[taskID - 1].setTag != Utility.KEYWORD_NULL)
            {
                editedTask.setTag = Storage.getTaskList()[taskID - 1].setTag;
            }

            else if (editedTask.setTag == Utility.EMPTY_STRING && Storage.getTaskList()[taskID - 1].setTag == Utility.KEYWORD_NULL)
            {
                editedTask.setTag = Utility.KEYWORD_NULL;
            }
        }

        private static void mergeTaskDescription(int taskID, Task editedTask)
        {
            if (editedTask.setTaskDescription == Utility.EMPTY_STRING 
                && Storage.getTaskList()[taskID - 1].setTaskDescription != Utility.KEYWORD_NULL)
            {
                editedTask.setTaskDescription = Storage.getTaskList()[taskID - 1].setTaskDescription;
            }

            else if (editedTask.setTaskDescription == Utility.EMPTY_STRING 
                && Storage.getTaskList()[taskID - 1].setTaskDescription == Utility.KEYWORD_NULL)
            {
                editedTask.setTaskDescription = Utility.KEYWORD_NULL;
            }
        }

        private void appendNonExistingFields(int taskID, Parser parseTask)
        {
            if (userInput.IndexOf(parseTask.shortcutsToString(Utility.shortcuts.ed)) == Utility.INVALID_INDEX)
            {
                userInput += Utility.SPACE_CHAR + Utility.hyphen + Utility.shortcuts.ed.ToString()
                            + Utility.SPACE_CHAR + Storage.getTaskList()[taskID - 1].setEnd.ToString(Utility.DATE_FORMAT);
                mergeTask(taskID);
            }

            if (userInput.IndexOf(parseTask.shortcutsToString(Utility.shortcuts.et)) == Utility.INVALID_INDEX)
            {
                userInput += Utility.SPACE_CHAR + Utility.hyphen + Utility.shortcuts.et.ToString() 
                            + Utility.SPACE_CHAR + Storage.getTaskList()[taskID - 1].setEnd.ToString(Utility.TIME_FORMAT);
                mergeTask(taskID);
            }

            if (userInput.IndexOf(parseTask.shortcutsToString(Utility.shortcuts.sd)) == Utility.INVALID_INDEX)
            {
                userInput += Utility.SPACE_CHAR + Utility.hyphen + Utility.shortcuts.sd.ToString()
                            + Utility.SPACE_CHAR + Storage.getTaskList()[taskID - 1].setStart.ToString(Utility.DATE_FORMAT);
                mergeTask(taskID);
            }

            if (userInput.IndexOf(parseTask.shortcutsToString(Utility.shortcuts.st)) == Utility.INVALID_INDEX)
            {
                userInput += Utility.SPACE_CHAR + Utility.hyphen + Utility.shortcuts.st.ToString()
                            + Utility.SPACE_CHAR + Storage.getTaskList()[taskID - 1].setStart.ToString(Utility.TIME_FORMAT);
                mergeTask(taskID);
            }
        }
    }
}
