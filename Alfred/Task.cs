using System;

namespace Alfred
{
    //@author A0088653R
    class Task
    {
        private DateTime end;
        public DateTime setEnd
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }

        private DateTime start;
        public DateTime setStart
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }


        private string taskDescription;
        public string setTaskDescription
        {
            get
            {
                return taskDescription;
            }
            set
            {
                taskDescription = value;
            }
        }

        private bool isCompleted;
        public bool setIsCompleted
        {
            get
            {
                return isCompleted;
            }
            set
            {
                isCompleted = value;
            }
        }

        private int taskID;
        public int setTaskID
        {
            get
            {
                return taskID;
            }
            set
            {
                taskID = value;
            }
        }

        private string category;
        public string setCategory
        {
            get
            {
                return category;
            }
            set
            {
                category = value;

            }
        }

        private string tag;
        public string setTag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }

        public static int CompareDates(Task x, Task y)
        {
            return x.setEnd.CompareTo(y.setEnd);
        }

        public Task getShallowTask()
        { 
            Task shallowcopy=(Task)this.MemberwiseClone();
            return shallowcopy;
        }
    }
}