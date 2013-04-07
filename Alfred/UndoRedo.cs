using System.Collections.Generic;

namespace Alfred
{
    //@author A0081050X
    class UndoRedo
    {
        private static Stack<List<Task>> undolist = new Stack<List<Task>>();
        private static Stack<List<Task>> redolist = new Stack<List<Task>>();

        public Stack<List<Task>> getUndolist() { return undolist; }
        public Stack<List<Task>> getRedolist() { return redolist; }
       
        public void addUndoTask()
        {
            List<Task> undoTask = Storage.getTaskListShallowcopy();
            undolist.Push(undoTask);
        }
        
        public void addRedoTask()
        {
            List<Task> redoTask = Storage.getTaskListShallowcopy();
            redolist.Push(redoTask);
        }

        public void undo()
        {
            addRedoTask();
            Storage.setTaskList(undolist.Pop());
            Storage.updateStorage();
        }

        public void redo()
        {
            Storage.setTaskList(redolist.Pop());
            Storage.updateStorage();
        }
    }
}