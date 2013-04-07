using log4net;
namespace Alfred
{
    class Delete
    {
        ILog log = LogManager.GetLogger(typeof(Delete));

        //@author A0088653R
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

        //@author A0081050X
        public string deleteTask(string input)
        {
            log4net.Config.XmlConfigurator.Configure();
            int index = getIndex(input);


            if (index == Utility.INVALID_INDEX)
            {
                log.Warn(Utility.LOG_INVALID_INDEX_PROMPT);
                return Utility.ERROR_INVALID_DELETE_FORMAT;
            }

            if (index > 0 && index <= Storage.getTaskList().Count)
            {
                log.Info(Utility.LOG_VALID_INDEX_PROMPT);

                Storage.removeData(index - 1);
                Storage.updateStorage();
                return Utility.STATUS_TASK_DELETED;
            }

            else
            {
                log.Warn(Utility.LOG_HIGHER_INDEX_PROMPT);
                return Utility.ERROR_INVALID_TASKNO;
            }

        }
    }
}
