namespace Alfred
{
    //@author A0088653R
    class Utility
    {
        public const string MAX_TIME = "23:59:59";
        public const string MAX_ALT_TIME = "12/31/9999 11:59:00 PM";
        public const string MIN_TIME = "12 am";
        public const int MAX_TASK_FIELDS = 7;
        public const int MAX_SHORTCUT_SIZE = 3;
        public const int MIN_SHORTCUT_SIZE = 2;
        public const string MIN_SIZE = "0";
        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const string TIME_FORMAT = "hh:mm tt";
        public const string TIME_FORMAT_STORAGE = "{0:hh:mm tt}";
       
        
        public const string COMMAND_ARCHIVE = "archive";
        public const string COMMAND_COMPLETE = "complete";
        public const string COMMAND_UNCOMPLETE = "uncomplete";
        public const string COMMAND_ADD = "add";
        public const string COMMAND_EDIT = "edit";
        public const string COMMAND_DELETE = "delete";
        public const string COMMAND_HELP = "help";
        public const string COMMAND_EXIT = "exit";
        public const string COMMAND_SEARCH = "search";
        public const string COMMAND_UNDO = "undo";
        public const string COMMAND_REDO = "redo";
        public const string COMMAND_ALL = "all";
        public const string COMMAND_CLEAR = "clear";

        public const string COMMAND_ADD_FORMAT = "add <task description> -st <start time> -sd <start date> -et <end time> -ed <end date> -t <tag>\n*No field is compulsory";
        public const string COMMAND_DELETE_FORMAT = "delete <Task no.>";
        public const string COMMAND_EDIT_FORMAT = "edit <Task no.> <task description> -st <start time> -sd <start date> -et <end time> \n-ed <end date> -t <tag>\n*No field is compulsory";
        public const string COMMAND_SEARCH_FORMAT = "search <Keyword>";
        public const string COMMAND_COMPLETE_FORMAT = "complete <Task no.>";
        public const string COMMAND_CLEAR_FORMAT = "Clear";

        public const string STATUS_CLEARED = "All tasks cleared successfully";
        public const string STATUS_INITIAL = "Welcome.\nAvailable commands are Add, Search, Delete, Edit, Undo, Redo, All, Clear, Complete,\nUncomplete, Archive, Help and Exit.";
        public const string STATUS_TASK_ADDED = "Task added successfully!";
        public const string STATUS_TASK_DELETED = "Task deleted successfully!";
        public const string STATUS_TASK_COMPLETED = "Task completed sucessfully!";
        public const string STATUS_TASK_UNCOMPLETED = "Task marked as incomplete!";
        public const string STATUS_TASK_EDITED = "Task edited successfully!";
        public const string STATUS_TASK_UNDO = "Undo successful!";
        public const string STATUS_TASK_REDO = "Redo successful!";


        public const string ERROR_INVALID_INPUT = "Please enter a valid command";
        public const string ERROR_INVALID_DATETIME = "Please enter a valid deadline";
        public const string ERROR_INVALID_TASKNO = "Please enter a valid task number";
        public const string ERROR_INVALID_DELETE_FORMAT = "Please enter Delete <task number>";
        public const string ERROR_INVALID_COMPLETE_FORMAT = "Please enter Complete <task number>";
        public const string ERROR_INVALID_EDIT_FORMAT = "Please enter Edit <valid task number> <-ed valid end date> <-et valid end time>";
        public const string ERROR_INVALID_UNDO_COMMAND = "Nothing to undo!";
        public const string ERROR_INVALID_REDO_COMMAND = "Nothing to redo!";
        public const string ERROR_NO_HELP_FILE = "No help file detected!";

       
        //Logging statements stored below
        public const string LOG_COMPLETE_COMMAND_STARTED = "Complete Command identified\n";
        public const string LOG_UNCOMPLETE_COMMAND_STARTED = "Uncomplete Command identified\n";
        public const string LOG_DETERMINE_COMMAND_STARTED = "Determine Command Started\n";
        public const string LOG_EXIT_COMMAND_IDENTIFIED= "Exit command identified\n";
        public const string LOG_UNDO_COMMAND_IDENTIFIED = "Undo command identified\n";
        public const string LOG_REDO_COMMAND_IDENTIFIED = "Redo command identified\n";
        public const string LOG_SEARCH_COMMAND_IDENTIFIED = "Search command identified\n";
        public const string LOG_DELETE_COMMAND_IDENTIFIED = "Delete command identified\n";
        public const string LOG_EDIT_COMMAND_IDENTIFIED = "Edit command identified\n";
        public const string LOG_ADD_COMMAND_IDENTIFIED = "Add command identified\n";
        public const string LOG_COMMAND_NOT_IDENTIFIED = "Command not identified , error shown to user\n";
        public const string LOG_ADD_FUNCTION_WORKING = "Add Function working\n";
        public const string LOG_INVALID_DATE_TIME_PROMPT = "Invalid date\time entered \n";
        public const string LOG_INVALID_INDEX_PROMPT = "Index specified is invalid, error shown to user\n";
        public const string LOG_VALID_INDEX_PROMPT = "Valid Index, Deletion of task started\n";
        public const string LOG_HIGHER_INDEX_PROMPT = "Invalid task number entered(>total), error shown to user\n";
        public const string LOG_INVALID_TASK_DATA_PROMPT = "Invalid task data\n";
        public const string LOG_PARSING_BEGINS = "Valid task data, parsing begins\n";
        public const string LOG_SEARCHING_BEGINS = "Searching begins\n";
        public const string LOG_END_DATE_SPECIFIED = "end date specified by user\n";
        public const string LOG_START_DATE_SPECIFIED = "start date specified by user\n";
        public const string LOG_START_DATE_NOT_SPECIFIED = "start date not specified\n";
        public const string LOG_END_DATE_NOT_SPECIFIED = "end date not specified\n";
        public const string LOG_RETURN_TASK = "Returning task from Parser class\n";

        public const string DATE_TODAY = "Today";
        public const string DATE_TOMORROW = "Tomorrow";

        public const string TASK_CTG_DEADLINE = "Deadline Task";
        public const string TASK_CTG_FLOATING = "Floating Task";
        public const string TASK_CTG_TIMED = "Timed Task";


        // misc
        public const int TASK_OVERFLOW = -5;
        public const int INVALID_INDEX = -1;
        public const string INVALID_STARTDATE_ENDDATE = "11:59PM 20/04/1600";
        public const string suffix = " -";
        public const string hyphen = "-";
        public const string DATA_FILE = "Data.txt";
        public const string HELP_FILE = "Help.html";
        public const string KEYWORD_NULL = "NULL";
        public const char SPACE_CHAR = ' ';
        public const string EMPTY_STRING = "";
        public enum shortcuts
        {
            sd,
            st,
            et,
            ed,
            t
        }
                
        //test variables
        public const string TEST_NORMAL_ADDTASK_NO_DETAILS = "normal task ";
        public const string TEST_NORMAL_ADDTASK_ST = "normal task -st 10am ";
        public const string TEST_NORMAL_ADDTASK_ST_ET = "normal task -st 10am -et 12 pm";
        public const string TEST_NORMAL_ADDTASK_ST_ET_SD = "normal task -st 10am -et 12 pm -sd 10/10/2012 ";
        public const string TEST_NORMAL_ADDTASK_ST_ET_ED = "normal task -st 10am -et 12 pm -ed 12/10/2013 ";
        public const string TEST_NORMAL_ADDTASK_ST_SD = "normal task -st 10am -sd 10/10/2012 ";
        public const string TEST_NORMAL_ADDTASK_ST_SD_ED = "normal task -st 10am -sd 10/10/2012 -ed 12/10/2013";
        public const string TEST_NORMAL_ADDTASK_ST_ED = "normal task -st 10am -ed 12/10/2013";
        public const string TEST_NORMAL_ADDTASK_ET = "normal task -et 12 pm";
        public const string TEST_NORMAL_ADDTASK_ET_SD = "normal task -et 12 pm -sd 10/10/2012";
        public const string TEST_NORMAL_ADDTASK_ET_SD_ED = "normal task -et 12 pm -sd 10/10/2012 -ed 12/10/2013";
        public const string TEST_NORMAL_ADDTASK_ET_ED = "normal task -et 12 pm -ed 12/10/2013";
        public const string TEST_NORMAL_ADDTASK_SD = "normal task -sd 10/10/2012";
        public const string TEST_NORMAL_ADDTASK_SD_ED = "normal task -sd 10 oct -ed 12/10/2013";
        public const string TEST_NORMAL_ADDTASK_ED = "normal task -ed 12/10/2013";
        public const string TEST_NORMAL_ADDTASK_ALL_TIME = "normal task -st 10am -et 12 pm -sd 10/10/2012 -ed 12/10/2013";
        public const string TEST_NORMAL_ADDTASK_ALL_TIME_T = "normal task -st 10am -et 12 pm -sd 10/10/2012 -ed 12/10/2013 -t TestTag";
        public const string TEST_NORMAL_ADDTASK_T = "normal task -t TestTag";

        public const string TEST_NORMAL_ADDTASK_1 = "Go shopping ";
        public const string TEST_NORMAL_ADDTASK_2 = "Go swimming ";
        public const string TEST_NORMAL_ADDTASK_3 = "Do my test cases for programming lab -st 8am -et 12pm -sd 8/10/12 -ed 10/10/12";
        public const string TEST_NORMAL_ADDTASK_4 = "Find swimming goggles -ed 12/12/2012";
        public const string TEST_NORMAL_ADDTASK_5 = "Do some questions in tutorial 6 then go shopping ";

        public const string TEST_WIERD_ADDTASK_MULTIPLE_ST = "wierd task -st 5pm -st 6pm";
        public const string TEST_WIERD_ADDTASK_ET_BEFORE_ST_SAME_DATE = "wierd task -st 5pm -et 6pm -sd 5/10/2012 -ed 5/10/2012";
        public const string TEST_WIERD_ADDTASK_MIXED_COMMANDS_ALL_TIME_T = "wierd task -t TestTag -ed 12/10/2012 -et 12 pm -sd 10/10/2012 -st 10am  ";

        public const string TEST_INVALID_ADDTASK_ET_BEFORE_ST = "wierd task -st 5pm -et 6am";
        public const string TEST_INVALID_ADDTASK_ED_BEFORE_SD = "invalid task -sd 5/10/12 -ed 4/10/12";
        public const string TEST_INVALID_ST_ADDTASK_ALL_TIME_T = "invalid task -st INVALIDTIME -et 12 pm -sd 10/10/2012 -ed 12/10/2012 -t TestTag";
        public const string TEST_INVALID_ET_ADDTASK_ALL_TIME_T = "invalid task -st 10am -et INVALIDTIME -sd 10/10/2012 -ed 12/10/2012 -t TestTag";
        public const string TEST_INVALID_SD_ADDTASK_ALL_TIME_T = "invalid task -st 10am -et 12pm -sd IMVALIDDATE -ed 12/10/2012 -t TestTag";
        public const string TEST_INVALID_ED_ADDTASK_ALL_TIME_T = "invalid task -st 10am -et 12pm -sd 10/10/2012 -ed INVALIDDATE -t TestTag";

        public const string TEST_DELETE_TASK_1 = "delete 1";
        public const string TEST_DELETE_TASK_3 = "delete 3";
        public const string TEST_DELETE_TASK_3_EXPECTED_TD = "Do my test cases for programming lab ";

        public const string TEST_EDIT_TASK_TASK = "Go fly fishing -st 6am -et 4pm -sd 10/01/2013 -ed 13/01/2013 -t Holiday";
        public const string TEST_EDIT_TASK_INITIAL_TASK_DESCRIPTION = "Go fly fishing";
        public const string TEST_EDIT_TASK_INITIAL_START = "10/01/2013 06:00:00 ";
        public const string TEST_EDIT_TASK_INITIAL_END = "13/01/2013 04:00:00 ";
        public const string TEST_EDIT_TASK_INITIAL_TAG = "Holiday";
        public const string TEST_EDIT_TASK_TASK_DESCRIPTION = "edit 1 Go shark fishing ";
        public const string TEST_EDITED_TASK_DESCRIPTION = "Go shark fishing";
        public const string TEST_EDIT_TASK_ST = "edit 1 -st 8am -sd 10/01/2013";
        public const string TEST_EDITED_TASK_ST = "10/01/2013 08:00:00 ";
        public const string TEST_EDIT_TASK_SD = "edit 1 -st 6am -sd 10/12/2012";
        public const string TEST_EDITED_TASK_SD = "10/12/2012 06:00:00 ";
        public const string TEST_EDIT_TASK_ET = "edit 1 -et 5pm -ed 13/01/2013";
        public const string TEST_EDITED_TASK_ET = "13/01/2013 17:00:00 ";
        public const string TEST_EDIT_TASK_ED = "edit 1 -et 4pm -ed 13/12/2012";
        public const string TEST_EDITED_TASK_ED = "13/12/2013 04:00:00 ";

        public const string TEST_STORAGE_TASK_EXPECTED = "Do my test cases for programming lab  08 oct. 08/10/12 08:00  10 oct. 10/10/12 12:00 ";

        public const string TEST_PARSER_TASK_ALL = "Go fly fishing -st 6am -et 4pm -sd 10/01/2013 -ed 13/01/2013 -t Holiday";
        public const string TEST_PARSER_TASK_DESCRIPTION = "Go fly fishing";
        public const string TEST_PARSER_START = "10/01/2013 06:00:00 ";
        public const string TEST_PARSER_END = "13/01/2013 16:00:00 ";
        public const string TEST_PARSERTAG = "Holiday";
        public const string TEST_PARSER_STARTDATE = "10/01/2013";
        public const string TEST_PARSER_ENDDATE = "13/01/2013";
        public const string TEST_PARSER_STARTTIME = "6am";
        public const string TEST_PARSER_ENDTIME = "4pm";

        public const string TEST_POWERSEARCH_KEYWORD1 = "Go";
        public const string TEST_POWERSEARCH_KEYWORD2 ="Go 12";
        public const string TEST_POWERSEARCH_KEYWORD3 = "Google";
        public const string TEST_POWERSEARCH_RESULT1 = "Find swimming goggles";
        public const string TEST_POWERSEARCH_RESULT2 = "Go swimming";
        public const string TEST_POWERSEARCH_RESULT3 = "Go shopping";

        public const string TEST_TASK_X = "Do my test cases for programming lab -st 8am -et 12pm -sd 8/10/12 -ed 10/10/12";
        public const string TEST_TASK_Y = "Go fly fishing -st 6am -et 4pm -sd 10/01/2013 -ed 13/01/2013 -t Holiday";

        public const string TEST_UNDOREDO_TASK = "Sleep for 8 hours";
        public const string TEST_UNDOREDO_COMPLETE = "complete 1";
    }
}
