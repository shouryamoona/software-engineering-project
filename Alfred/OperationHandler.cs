using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using log4net;

namespace Alfred
{
    class OperationHandler
    {    
             
        //@author A0091525H
        public static List<Task> determineCommand(string input)
        {
            ILog log = LogManager.GetLogger(typeof(OperationHandler));
            log4net.Config.XmlConfigurator.Configure();
            log.Info(Utility.LOG_DETERMINE_COMMAND_STARTED);

            List<string> prevCommand = new List<string>();
            string command = extractFirstWord(input + Utility.SPACE_CHAR);
            UndoRedo undoRedoObj = new UndoRedo();

            prevCommand.Add(command);

            if (String.Equals(input, Utility.COMMAND_EXIT, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_EXIT_COMMAND_IDENTIFIED);
                Process p = Process.GetCurrentProcess();
                p.Kill();
                return Storage.getTaskList();
            }
            
            else if (string.Equals(command, Utility.COMMAND_ARCHIVE, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                Complete completeObj = new Complete();
                return completeObj.returnCompletedTaskList();
            }

            else if (string.Equals(input, Utility.COMMAND_HELP, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                showHelp();
                return Storage.getTaskList();
            }

            else if (string.Equals(input, Utility.COMMAND_UNDO, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_UNDO_COMMAND_IDENTIFIED);
                if (undoRedoObj.getUndolist().Count == 0)
                {
                    UI.statusMessageLabel.Text = Utility.ERROR_INVALID_UNDO_COMMAND;
                }
                else
                {
                    undoRedoObj.undo();
                    UI.statusMessageLabel.Text = Utility.STATUS_TASK_UNDO;
                }
                return Storage.getTaskList();
            }

            else if (string.Equals(input, Utility.COMMAND_REDO, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_REDO_COMMAND_IDENTIFIED);
                if (undoRedoObj.getRedolist().Count == 0)
                {
                    UI.statusMessageLabel.Text = Utility.ERROR_INVALID_REDO_COMMAND;
                }
                else
                {
                    undoRedoObj.redo();
                    UI.statusMessageLabel.Text = Utility.STATUS_TASK_REDO;
                }
                return Storage.getTaskList();
            }

            else if (string.Equals(command, Utility.COMMAND_COMPLETE, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_COMPLETE_COMMAND_STARTED);
                undoRedoObj.addUndoTask();
                
                Complete completeObj = new Complete();
                
                UI.statusMessageLabel.Text = completeObj.changeCompleteStatus(input,true);

                return Storage.getTaskList();
            }

            else if (string.Equals(command, Utility.COMMAND_UNCOMPLETE, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_UNCOMPLETE_COMMAND_STARTED);
                undoRedoObj.addUndoTask();

                Complete completeObj = new Complete();

                UI.statusMessageLabel.Text = completeObj.changeCompleteStatus(input,false);

                return Storage.getTaskList();
            }
                  
            else if (String.Equals(command, Utility.COMMAND_SEARCH, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_SEARCH_COMMAND_IDENTIFIED);
                input = input + Utility.SPACE_CHAR;
                int firstIndex = input.IndexOf(Utility.SPACE_CHAR);
                int lastIndex = input.Length;
                string searchKeyword = input.Substring(firstIndex, input.Length - firstIndex - 1).Trim();

                return PowerSearch.instantSearch(searchKeyword);
            }

            else if (string.Equals(command, Utility.COMMAND_DELETE, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_DELETE_COMMAND_IDENTIFIED);
                undoRedoObj.addUndoTask();
                Delete deleteObj = new Delete();
                UI.statusMessageLabel.Text = deleteObj.deleteTask(input);
                return Storage.getTaskList();
            }

            else if (string.Equals(command, Utility.COMMAND_CLEAR, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                undoRedoObj.addUndoTask();
                Storage.getTaskList().Clear();
                Storage.updateStorage();
                UI.statusMessageLabel.Text = Utility.STATUS_CLEARED;
                return Storage.getTaskList();
            }


            else if (string.Equals(command, Utility.COMMAND_EDIT, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                log.Info(Utility.LOG_EDIT_COMMAND_IDENTIFIED);
                undoRedoObj.addUndoTask();
                Edit editobj = new Edit();
                UI.statusMessageLabel.Text = editobj.editTask(input);
                return Storage.getTaskList();
            }

            else if (string.Equals(command, Utility.COMMAND_ALL, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                return Storage.getTaskList();
            }

            else if (string.Equals(command, Utility.COMMAND_ADD, StringComparison.CurrentCultureIgnoreCase) == true || input.Length != 0)
            {
                log.Info(Utility.LOG_ADD_COMMAND_IDENTIFIED);
                undoRedoObj.addUndoTask();
                Add addObj = new Add();
                UI.statusMessageLabel.Text = addObj.addTask(input);
                return Storage.getTaskList();
            }


            else
            {
                log.Info(Utility.LOG_COMMAND_NOT_IDENTIFIED);
                UI.statusMessageLabel.Text = Utility.ERROR_INVALID_INPUT;
                return Storage.getTaskList();
            }
        }

        //@author A0081050X
        public static string extractFirstWord(string input)
        {
            int size = input.IndexOf(Utility.SPACE_CHAR);
            string command = input.Substring(0, size);
            return command.Trim();
        }

        //@author A0088653R
        private static void showHelp()
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