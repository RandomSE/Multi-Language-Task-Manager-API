<?php
header("Content-Type: application/json");

$dataFile = 'tasks.json';

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    // Retrieve all tasks
    if (file_exists($dataFile)) {
        $tasks = file_get_contents($dataFile);
        echo $tasks;
    } else {
        echo json_encode([]);
    }
} elseif ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // Add a new task
    $input = json_decode(file_get_contents('php://input'), true);
    if (!isset($input['task'])) {
        http_response_code(400);
        echo json_encode(['error' => 'Task is required']);
        exit;
    }

    $task = [
        'id' => uniqid(),
        'task' => $input['task'],
        'completed' => false
    ];

    if (file_exists($dataFile)) {
        $tasks = json_decode(file_get_contents($dataFile), true);
    } else {
        $tasks = [];
    }

    $tasks[] = $task;
    file_put_contents($dataFile, json_encode($tasks));

    echo json_encode($task);
} elseif ($_SERVER['REQUEST_METHOD'] === 'DELETE') {
    // Delete a task
    if (!isset($_GET['id'])) {
        http_response_code(400);
        echo json_encode(['error' => 'ID is required']);
        exit;
    }

    $id = $_GET['id'];
    if (file_exists($dataFile)) {
        $tasks = json_decode(file_get_contents($dataFile), true);
        $tasks = array_filter($tasks, function($task) use ($id) {
            return $task['id'] !== $id;
        });
        file_put_contents($dataFile, json_encode($tasks));
        echo json_encode(['status' => 'Task deleted']);
    } else {
        http_response_code(404);
        echo json_encode(['error' => 'Task not found']);
    }
} else {
    http_response_code(405);
    echo json_encode(['error' => 'Method not allowed']);
}
?>
