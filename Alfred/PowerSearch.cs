using System.Collections.Generic;
using log4net;
namespace Alfred
{
    //@author A0088589B
    class PowerSearch
    {
        private static List<Task> oldResults = new List<Task>();
        private static List<Task> searchResults = new List<Task>();
        private static int[] ifPreviousResultsFull = new int[4];

        PowerSearch()
        {
            for (int i = 0; i < 3; i++)
            {
                ifPreviousResultsFull[i] = 0;
            }
        }

        private static ILog log = LogManager.GetLogger(typeof(PowerSearch));

        public static List<Task> instantSearch(string searchKeyword)
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info(Utility.LOG_SEARCHING_BEGINS);

            if (searchResults.Count != 0)
            {
                oldResults = searchResults;
            }

            searchResults = new List<Task>();

            for (int i = 0; i < Storage.getStringTaskList().Count; i++)
            {
                int keywordsFound = 0;
                
                // split search keyword into string list with different words in each index
                string[] searchKeywordSplitArray = searchKeyword.Split(Utility.SPACE_CHAR);

                for (int j = 0; j < searchKeywordSplitArray.Length; j++)
                {
                    // check if search keyword in index j is found in stringTaskList[i]
                    if (Storage.getStringTaskList()[i].ToUpper().IndexOf(searchKeywordSplitArray[j].ToUpper()) != Utility.INVALID_INDEX)
                    {
                        keywordsFound++;
                    }
                }

                if (keywordsFound == searchKeywordSplitArray.Length)
                {
                    try
                    {
                        searchResults.Add(Storage.getTaskList()[i]);
                    }
                    catch
                    {

                    }
                }
            }

            updateCount();

            if (isNoResultsFound() && searchKeyword.Length > 1)
            {
                return oldResults;
            }

            return searchResults;
        }

        private static bool isNoResultsFound()
        {
            return (ifPreviousResultsFull[0] == 1 || ifPreviousResultsFull[1] == 1 || ifPreviousResultsFull[2] == 1)
                && ifPreviousResultsFull[3] == 0;
        }

        private static void updateCount()
        {
            for (int i = 0; i < 3; i++)
            {
                ifPreviousResultsFull[i] = ifPreviousResultsFull[i + 1];
            }

            switch (searchResults.Count)
            {
                case 0:
                    ifPreviousResultsFull[3] = 0;
                    break;

                default:
                    ifPreviousResultsFull[3] = 1;
                    break;
            }
        }
    }
}

