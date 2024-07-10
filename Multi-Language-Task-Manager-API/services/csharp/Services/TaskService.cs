using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<Task> _tasks = new();
        private int _nextId = 1;

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task GetTask(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void CreateTask(Task task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public bool UpdateTask(int id, Task updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return false;
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.IsCompleted = updatedTask.IsCompleted;
            task.Priority = updatedTask.Priority;
            task.DueDate = updatedTask.DueDate;

            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return false;
            }

            _tasks.Remove(task);
            return true;
        }

        public bool MarkTaskAsCompleted(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return false;
            }

            task.IsCompleted = true;
            return true;
        }

        public IEnumerable<Task> FilterTasks(bool? isCompleted, int? priority, DateTime? dueDate)
        {
            return _tasks.Where(t =>
                (!isCompleted.HasValue || t.IsCompleted == isCompleted.Value) &&
                (!priority.HasValue || t.Priority == priority.Value) &&
                (!dueDate.HasValue || t.DueDate.Date == dueDate.Value.Date));
        }
    }
}
