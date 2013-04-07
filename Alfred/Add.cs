using System;
using log4net;
namespace Alfred
{
    //@author A0088653R
    class Add
    {
        ILog log = LogManager.GetLogger(typeof(Add));
        Task newTask;
        Parser parseInput = new Parser();

        public string addTask(string input)
        {
            log4net.Config.XmlConfigurator.Configure();
            newTask = parseInput.returnTask(input).getShallowTask();
            isTaskDescriptionNull();

            if (newTask.setEnd != DateTime.MinValue && newTask.setStart != DateTime.MinValue 
                && newTask.setStart != DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE) 
                && newTask.setEnd != DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE))
            {
                log.Info(Utility.LOG_ADD_FUNCTION_WORKING);
                Storage.addData(newTask);
                Storage.updateStorage();
                return Utility.STATUS_TASK_ADDED;
            }

            else
            {
                log.Warn(Utility.LOG_INVALID_DATE_TIME_PROMPT);
                return Utility.ERROR_INVALID_DATETIME;
            }

        }

        private void isTaskDescriptionNull()
        {
            if (newTask.setTaskDescription == Utility.EMPTY_STRING)
            {
                newTask.setTaskDescription = Utility.KEYWORD_NULL;
            }
        }

    }
}
