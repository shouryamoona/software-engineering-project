using System;
using System.Globalization;
using System.Threading;
using log4net;
namespace Alfred
{
    class Parser
    {
        ILog log = LogManager.GetLogger(typeof(Parser));
        private DateTime end;
        private DateTime start;
        private Task newTask = new Task();

        public string shortcutsToString(Utility.shortcuts current)
        {
            return Utility.hyphen + current;
        }

        //@author A0091525H
        private string parseEndDate(string input)
        {
            log4net.Config.XmlConfigurator.Configure();
            // set date format to dd/mm/yyyy
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            int startPosition = input.IndexOf(shortcutsToString(Utility.shortcuts.ed));
            int endPosition = 0;
            string endDate;
            setEndAndStartPosition(input, ref startPosition, ref endPosition);

            if (startPosition == endPosition)
            {
                log.Info(Utility.TASK_CTG_FLOATING + "\n");
                endDate = DateTime.MaxValue.ToString();
            }

            else
            {
                log.Info(Utility.LOG_END_DATE_SPECIFIED);
                endDate = input.Substring(startPosition, endPosition - startPosition);
            }

            endDate = endDate.Trim();
            isDateTodayOrTomorrow(ref endDate);

            if (isInvalidDateTime(endDate) == true)
            {
                log.Warn(Utility.LOG_INVALID_DATE_TIME_PROMPT);
                return Utility.ERROR_INVALID_DATETIME;
            }

            return endDate.Trim();
        }

        private string parseStartDate(string input)
        {
            // set date format to dd/mm/yyyy
            log4net.Config.XmlConfigurator.Configure();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            int startPosition = input.IndexOf(shortcutsToString(Utility.shortcuts.sd));
            int endPosition = 0;
            string startDate;
            setEndAndStartPosition(input, ref startPosition, ref endPosition);

            if (startPosition == endPosition) // if no start date mentioned
            {
                log.Warn(Utility.LOG_START_DATE_NOT_SPECIFIED);
                startDate = DateTime.MaxValue.ToString();
            }
            else
            {
                log.Info(Utility.LOG_START_DATE_SPECIFIED);
                startDate = input.Substring(startPosition, endPosition - startPosition);
            }

            startDate = startDate.Trim();
            isDateTodayOrTomorrow(ref startDate);

            if (isInvalidDateTime(startDate) == true)
            {
                log.Warn(Utility.LOG_INVALID_DATE_TIME_PROMPT);
                return Utility.ERROR_INVALID_DATETIME;
            }
            return startDate.Trim();
        }

        //@author A0088589B
        // exception handling for invalid date time
        private static bool isInvalidDateTime(string dateTime)
        {

            try
            {
                DateTime.Parse(dateTime);
            }

            catch
            {
                return true;
            }

            return false;
        }

        private int setEndAndStartPosition(string input, ref int startPosition, ref int endPosition)
        {

            if (startPosition == Utility.INVALID_INDEX)
            {
                startPosition = 0;
                endPosition = 0;
            }

            else
            {
                startPosition += Utility.MAX_SHORTCUT_SIZE;
                endPosition = startPosition;
                endPosition = indexBeforeNextHyphen(input, startPosition, endPosition);
            }

            return endPosition;
        }

        private static void isDateTodayOrTomorrow(ref string endDate)
        {

            if (string.Equals(endDate, Utility.DATE_TODAY, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                endDate = DateTime.Today.ToShortDateString();
            }


            else if (string.Equals(endDate, Utility.DATE_TOMORROW, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                endDate = DateTime.Today.AddDays(1).ToShortDateString();
            }

        }

        private static int indexBeforeNextHyphen(string input, int startPosition, int endPosition)
        {
            int i;
            char hyphen = Utility.hyphen[0];
            for (i = startPosition; i < input.Length; i++)
            {

                if (input[i] == hyphen)
                {

                    break;
                }
            }

            endPosition = i;
            return endPosition;
        }

        private string parseEndTime(string input)
        {
            int startPosition = input.IndexOf(shortcutsToString(Utility.shortcuts.et));
            int endPosition = 0;
            string endTime;
            setEndAndStartPosition(input, ref startPosition, ref endPosition);

            if (startPosition == endPosition)
            {
                endTime = DateTime.MaxValue.ToString(); ;
            }

            else
            {
                endTime = input.Substring(startPosition, endPosition - startPosition);
            }


            if (isInvalidDateTime(endTime) == true)
            {
                return Utility.ERROR_INVALID_DATETIME;
            }

            return endTime.Trim();
        }

        private string parseStartTime(string input)
        {
            int startPosition = input.IndexOf(shortcutsToString(Utility.shortcuts.st));
            int endPosition = 0;
            string startTime;
            setEndAndStartPosition(input, ref startPosition, ref endPosition);

            if (startPosition == endPosition)
            {
                startTime = DateTime.MaxValue.ToString(); ;
            }

            else
            {
                startTime = input.Substring(startPosition, endPosition - startPosition);
            }

            if (isInvalidDateTime(startTime) == true)
            {
                return Utility.ERROR_INVALID_DATETIME;
            }

            return startTime.Trim();
        }

        //@author A0091525H
        private string parseTaskDescription(string input)
        {
            if (string.Equals(input, Utility.COMMAND_ADD, StringComparison.CurrentCultureIgnoreCase) == true 
                || input == shortcutsToString(Utility.shortcuts.et) || input == shortcutsToString(Utility.shortcuts.ed) 
                || input == shortcutsToString(Utility.shortcuts.t) || input == shortcutsToString(Utility.shortcuts.st) 
                || input == shortcutsToString(Utility.shortcuts.sd))
            {
                return input;
            }

            input = addCorrectSuffix(input);
            string taskDescription = Utility.EMPTY_STRING;
            int firstIndex = input.IndexOf(Utility.SPACE_CHAR);
            int lastIndex;

            if (input.IndexOf(Utility.hyphen) == input.Length - 1)
            {
                return input.Substring(firstIndex, (input.Length - 1) - firstIndex).Trim();
            }

            else if (input.Substring(input.IndexOf(Utility.hyphen), 3) == shortcutsToString(Utility.shortcuts.ed)
                     || input.Substring(input.IndexOf(Utility.hyphen), Utility.MAX_SHORTCUT_SIZE) == shortcutsToString(Utility.shortcuts.et)
                     || input.Substring(input.IndexOf(Utility.hyphen), Utility.MIN_SHORTCUT_SIZE) == shortcutsToString(Utility.shortcuts.t)
                     || input.Substring(input.IndexOf(Utility.hyphen), Utility.MAX_SHORTCUT_SIZE) == shortcutsToString(Utility.shortcuts.sd)
                     || input.Substring(input.IndexOf(Utility.hyphen), Utility.MAX_SHORTCUT_SIZE) == shortcutsToString(Utility.shortcuts.st))
            {
                lastIndex = input.IndexOf(Utility.hyphen) - 1;
            }

            else
            {
                lastIndex = input.Length - 1;
            }

            taskDescription = input.Substring(firstIndex, lastIndex - firstIndex).Trim();
            return taskDescription;
        }

        private static string addCorrectSuffix(string input)
        {
            int size = input.IndexOf(Utility.SPACE_CHAR);
            string firstWord;
            if (size == -1)
            {
                firstWord = input.Substring(0);
            }
            else
            {
                firstWord = input.Substring(0, size);
            }
            firstWord = firstWord.Trim();

            if (string.Equals(firstWord, Utility.COMMAND_ADD, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                input += Utility.suffix;
            }

            else
            {
                input = Utility.COMMAND_ADD + Utility.SPACE_CHAR + input + Utility.suffix;
            }

            return input;
        }

        //@author A0088589B
        private string parseTag(string input)
        {
            string tag;

            if (input.IndexOf(shortcutsToString(Utility.shortcuts.t)) == -1)
            {
                return Utility.EMPTY_STRING;
            }

            int firstIndex = input.IndexOf(shortcutsToString(Utility.shortcuts.t)) + Utility.MAX_SHORTCUT_SIZE;
            int lastIndex = firstIndex;
            lastIndex = indexBeforeNextHyphen(input, firstIndex, lastIndex);
            tag = input.Substring(firstIndex, lastIndex - firstIndex);
            return tag.Trim();
        }

        //@author A0081050X
        private void combineDateTime(string input)
        {
            string endDate = parseEndDate(input);
            string endTime = parseEndTime(input);
            string startDate = parseStartDate(input);
            string startTime = parseStartTime(input);
            // set date format to dd/mm/yyyy
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            try
            {

                if (endDate == Utility.ERROR_INVALID_DATETIME || endTime == Utility.ERROR_INVALID_DATETIME 
                    || startTime == Utility.ERROR_INVALID_DATETIME || startDate == Utility.ERROR_INVALID_DATETIME)
                {
                    end = DateTime.MinValue;
                    start = DateTime.MinValue;
                    return;
                }

                // nothing 0 0 0 0
                if (endDate == DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString() 
                    && startTime == DateTime.MaxValue.ToString() && startDate == DateTime.MaxValue.ToString())
                {
                    end = DateTime.MaxValue;
                    start = DateTime.MaxValue;
                    newTask.setCategory = Utility.TASK_CTG_FLOATING;
                }

                // et 0 0 0 1
                else if (endDate == DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString() 
                         && startTime == DateTime.MaxValue.ToString() && startDate == DateTime.MaxValue.ToString())
                {
                    hasTimePassed(ref endTime);
                    start = DateTime.Now;
                    end = DateTime.Parse(endTime);
                    newTask.setCategory = Utility.TASK_CTG_DEADLINE;
                }

                // ed 0 0 1 0
                else if (endDate != DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString() 
                         && startTime == DateTime.MaxValue.ToString() && startDate == DateTime.MaxValue.ToString())
                {
                    if (DateTime.Parse(endDate) < DateTime.Today)
                    {
                        end = DateTime.Parse(Utility.MAX_TIME + Utility.SPACE_CHAR + endDate);
                        start = DateTime.MaxValue;
                    }

                    else
                    {
                        start = DateTime.Now;
                        end = DateTime.Parse(Utility.MAX_TIME + Utility.SPACE_CHAR + endDate);
                        newTask.setCategory = Utility.TASK_CTG_DEADLINE;
                    }
                }


                // ed, et 0 0 1 1
                else if (endDate != DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString() 
                         && startDate == DateTime.MaxValue.ToString() && startTime == DateTime.MaxValue.ToString())
                {
                    if (DateTime.Parse(endDate) < DateTime.Today)
                    {
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }

                    else
                    {
                        start = DateTime.Now;
                        end = DateTime.Parse(endDate + Utility.SPACE_CHAR + endTime);
                        newTask.setCategory = Utility.TASK_CTG_DEADLINE;
                    }
                }

                // st 0 1 0 0
                else if (endDate == DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString() 
                         && startTime != DateTime.MaxValue.ToString() && startDate == DateTime.MaxValue.ToString())
                {
                    start = DateTime.Parse(startTime + Utility.SPACE_CHAR + DateTime.Today.ToShortDateString());
                    end = DateTime.MaxValue;
                    newTask.setCategory = Utility.TASK_CTG_FLOATING;
                }

                // st,et 0 1 0 1
                else if (endDate == DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString() 
                         && startTime != DateTime.MaxValue.ToString() && startDate == DateTime.MaxValue.ToString())
                {
                    if (DateTime.Parse(startTime) < DateTime.Parse(endTime))
                    {
                        start = DateTime.Parse(startTime + Utility.SPACE_CHAR + DateTime.Today.ToShortDateString());
                        end = DateTime.Parse(endTime + Utility.SPACE_CHAR + DateTime.Today.ToShortDateString());
                        newTask.setCategory = Utility.TASK_CTG_TIMED;
                    }

                    else
                    {
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }

                }

                // st, ed 0 1 1 0
                else if (endDate != DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString()
                         && startTime != DateTime.MaxValue.ToString() && startDate == DateTime.MaxValue.ToString())
                {
                    if (DateTime.Parse(endDate) < DateTime.Today)
                    {
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }
                    else
                    {
                        start = DateTime.Parse(startTime + Utility.SPACE_CHAR + DateTime.Today.ToShortDateString());
                        end = DateTime.Parse(endDate + Utility.SPACE_CHAR + Utility.MAX_TIME);
                        newTask.setCategory = Utility.TASK_CTG_TIMED;
                    }
                }

                // st,ed,et 0 1 1 1
                else if (endDate != DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString() 
                         && startTime != DateTime.MaxValue.ToString() && startDate == DateTime.MaxValue.ToString())
                {


                    if (DateTime.Parse(startTime) > DateTime.Parse(endTime))
                    {
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }

                    else
                    {
                        start = DateTime.Parse(startTime + Utility.SPACE_CHAR + endDate);
                        end = DateTime.Parse(endTime + Utility.SPACE_CHAR + endDate);
                    }

                    newTask.setCategory = Utility.TASK_CTG_TIMED;
                }

                // sd 1 0 0 0 
                else if (endDate == DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString() 
                         && startTime == DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {
                    start = DateTime.Parse(startDate + Utility.SPACE_CHAR + Utility.MIN_TIME);
                    end = DateTime.MaxValue;
                    newTask.setCategory = Utility.TASK_CTG_FLOATING;
                }

                // sd, et 1 0 0 1
                else if (endDate == DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString()
                         && startTime == DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {
                    start = DateTime.Parse(startDate + Utility.SPACE_CHAR + DateTime.Today.ToShortTimeString());
                    end = DateTime.Parse(startDate + Utility.SPACE_CHAR + endTime);
                    newTask.setCategory = Utility.TASK_CTG_TIMED;
                }

                // sd, ed 1 0 1 0
                else if (endDate != DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString() 
                         && startTime == DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {

                    if (isStartDateLessThanEndDate(startDate, endDate))
                    {
                        start = DateTime.Parse(startDate + Utility.SPACE_CHAR + DateTime.Today.ToShortTimeString());
                        end = DateTime.Parse(endDate + Utility.SPACE_CHAR + Utility.MAX_TIME);
                        newTask.setCategory = Utility.TASK_CTG_TIMED;
                    }

                    else
                    {
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }
                }

                // sd, ed, et 1 0 1 1
                else if (endDate != DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString() 
                         && startTime == DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {
                    if (isStartDateLessThanEndDate(startDate, endDate))
                    {
                        start = DateTime.Parse(startDate + Utility.SPACE_CHAR + DateTime.Today.ToShortTimeString());
                        end = DateTime.Parse(endDate + Utility.SPACE_CHAR + endTime);
                        newTask.setCategory = Utility.TASK_CTG_TIMED;
                    }

                    else
                    {
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }
                }

                // sd, st 1 1 0 0 
                else if (endDate == DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString() 
                         && startTime != DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {
                    start = DateTime.Parse(startDate + Utility.SPACE_CHAR + startTime);
                    end = DateTime.MaxValue;
                    newTask.setCategory = Utility.TASK_CTG_FLOATING;
                }

                // sd, st, et 1 1 0 1
                else if (endDate == DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString() 
                         && startTime != DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {
                    start = DateTime.Parse(startDate + Utility.SPACE_CHAR + startTime);

                    if (DateTime.Parse(startTime) > DateTime.Parse(endTime))
                    {
                        end = DateTime.Parse(endTime + Utility.SPACE_CHAR + DateTime.Parse(startDate).AddDays(1).ToShortDateString());
                    }

                    else
                    {
                        end = DateTime.Parse(endTime + Utility.SPACE_CHAR + startDate);
                    }

                    newTask.setCategory = Utility.TASK_CTG_TIMED;
                }

                // sd, st, ed 1 1 1 0
                else if (endDate != DateTime.MaxValue.ToString() && endTime == DateTime.MaxValue.ToString() 
                         && startTime != DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {
                    if (isStartDateLessThanEndDate(startDate, endDate))
                    {
                        start = DateTime.Parse(startDate + Utility.SPACE_CHAR + startTime);
                        end = DateTime.Parse(endDate + Utility.SPACE_CHAR + Utility.MAX_TIME);
                        newTask.setCategory = Utility.TASK_CTG_TIMED;
                    }
                    else
                    {
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }
                }

                // sd, st, ed, et 1 1 1 1
                else if (endDate != DateTime.MaxValue.ToString() && endTime != DateTime.MaxValue.ToString() 
                         && startTime != DateTime.MaxValue.ToString() && startDate != DateTime.MaxValue.ToString())
                {
                    if (isStartDateLessThanEndDate(startDate, endDate))
                    {
                        if (DateTime.Parse(startDate) == DateTime.Parse(endDate))
                        {

                            if (DateTime.Parse(startTime) > DateTime.Parse(endTime))
                            {
                                start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                                end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);

                            }
                            else
                            {
                                start = DateTime.Parse(startDate + Utility.SPACE_CHAR + startTime);
                                end = DateTime.Parse(endDate + Utility.SPACE_CHAR + endTime);
                                newTask.setCategory = Utility.TASK_CTG_TIMED;
                            }
                        }
                        else
                        {
                            start = DateTime.Parse(startDate + Utility.SPACE_CHAR + startTime);
                            end = DateTime.Parse(endDate + Utility.SPACE_CHAR + endTime);
                            newTask.setCategory = Utility.TASK_CTG_TIMED;
                        }
                    }

                    else
                    {
                        start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                        end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                    }
                }
            }

            catch
            {
                start = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
                end = DateTime.Parse(Utility.INVALID_STARTDATE_ENDDATE);
            }
        }

        //@author A0088589B
        private static bool isStartDateLessThanEndDate(string startDate, string endDate)
        {
            return (DateTime.Parse(endDate) >= DateTime.Parse(startDate));
        }

        private static void hasTimePassed(ref string endTime)
        {
            if (DateTime.Parse(endTime) < DateTime.Now)
            {
                string temp = DateTime.Today.AddDays(1).ToShortDateString();
                endTime = temp + Utility.SPACE_CHAR + endTime;
            }
        }

        //@author A0088653R
        public Task returnTask(string input)
        {
            log.Info(Utility.LOG_RETURN_TASK);
            newTask.setTaskDescription = parseTaskDescription(input);
            input += Utility.suffix;
            combineDateTime(input);
            newTask.setEnd = end;
            newTask.setStart = start;
            newTask.setTag = parseTag(input);
            newTask.setIsCompleted = false;
            return newTask;
        }
    }
}