using System.Collections.Generic;
using log4net;
namespace Alfred
{

    //@author A0091525H
    class Complete
    {
        ILog log = LogManager.GetLogger(typeof(Complete));
        private List<Task> completedTasks = new List<Task>();

        public int getIndex(string input)
        {
            int index;
            index = input.IndexOf(Utility.SPACE_CHAR);
            input = input.Substring(index + 1);

            try
            {
                index = int.Parse(input);
            }
            catch
            {
                return Utility.INVALID_INDEX;
            }
            return index;
        }

        public void updateCompletedTaskList()
        {
            Task current = new Task();
            for (int i = 0; i < Storage.getTaskList().Count; i++)
            {
                current = Storage.getTaskList()[i];
                if (current.setIsCompleted == true)
                {
                    completedTasks.Add(current);
                }
            }
        }

        public string changeCompleteStatus(string input, bool completeUncomplete)
        {
            log4net.Config.XmlConfigurator.Configure();
            int index = getIndex(input);

            if (index == Utility.INVALID_INDEX)
            {
                log.Warn(Utility.LOG_INVALID_INDEX_PROMPT);
                return Utility.ERROR_INVALID_COMPLETE_FORMAT;
            }

            if (index > 0 && index <= Storage.getTaskList().Count)
            {
                log.Info(Utility.LOG_VALID_INDEX_PROMPT);

                //Marking task as completed or uncompleted
                Storage.getTaskList()[index - 1].setIsCompleted = completeUncomplete;

                //Adding task to completedTask list
                updateCompletedTaskList();

                Storage.updateStorage();

                if (completeUncomplete == true)
                {
                    return Utility.STATUS_TASK_COMPLETED;
                }
                else
                {
                    return Utility.STATUS_TASK_UNCOMPLETED;
                }
            }

            else
            {
                log.Warn(Utility.LOG_HIGHER_INDEX_PROMPT);
                return Utility.ERROR_INVALID_TASKNO;
            }

        }

        public List<Task> returnCompletedTaskList()
        {
            updateCompletedTaskList();
            return completedTasks;
        }
    }
}

    

