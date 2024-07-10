using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetAllTasks()
        {
            return Ok(_taskService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTask(int id)
        {
            var task = _taskService.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Task> CreateTask(Task task)
        {
            _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, Task updatedTask)
        {
            if (!_taskService.UpdateTask(id, updatedTask))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            if (!_taskService.DeleteTask(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public ActionResult MarkTaskAsCompleted(int id)
        {
            if (!_taskService.MarkTaskAsCompleted(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<Task>> FilterTasks([FromQuery] bool? isCompleted, [FromQuery] int? priority, [FromQuery] DateTime? dueDate)
        {
            return Ok(_taskService.FilterTasks(isCompleted, priority, dueDate));
        }
    }
}
