document.getElementById('taskForm').addEventListener('submit', function(e) {
    e.preventDefault();
    
    const taskInput = document.getElementById('taskInput');
    const taskList = document.getElementById('taskList');

    const li = document.createElement('li');
    li.textContent = taskInput.value;
    
    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', function() {
        taskList.removeChild(li);
    });

    li.appendChild(deleteButton);
    taskList.appendChild(li);

    taskInput.value = '';
});
