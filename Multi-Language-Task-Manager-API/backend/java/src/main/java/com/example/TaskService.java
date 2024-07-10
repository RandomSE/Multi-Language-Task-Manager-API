package com.example;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@SpringBootApplication
public class TaskService {

    public static void main(String[] args) {
        SpringApplication.run(TaskService.class, args);
    }
}

@RestController
@RequestMapping("/tasks")
class TaskController {

    private List<String> tasks = new ArrayList<>();

    @GetMapping
    public List<String> getTasks() {
        return tasks;
    }

    @PostMapping
    public String addTask(@RequestBody String task) {
        tasks.add(task);
        return task;
    }

    @DeleteMapping("/{id}")
    public String deleteTask(@PathVariable int id) {
        if (id >= 0 && id < tasks.size()) {
            return tasks.remove(id);
        } else {
            throw new TaskNotFoundException();
        }
    }

    @ResponseStatus(value = org.springframework.http.HttpStatus.NOT_FOUND, reason = "Task not found")
    public class TaskNotFoundException extends RuntimeException {
    }
}
