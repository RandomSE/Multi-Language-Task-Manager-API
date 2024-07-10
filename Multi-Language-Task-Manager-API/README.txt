
// Should work on Linux systems (as Docker is also Linux based) but if it's not well then, more adjustment.
So to actually this you will have to have a few things, while you can use other applications, I will only recommend the ones I have personally used.




-Deploy the Python backend  via Docker.
in the terminal:
cd backend\python
docker build -t taskmanager-python-backend .
docker run -d -p 5000:5000 taskmanager-python-backend

-Deploy the PHP backend on an Apache server in Docker. 
// You do not need to use XAMPP or apache, the dockerfile already has the specifics needed for it to run in Docker.
in a new instance of the terminal: 
cd backend/php
docker build -t taskmanager-php-backend .
docker run -d -p 8080:80 taskmanager-php-backend



-Deploy the Java backend  as a Docker container. You may have to disable SSL verification in the .m2 folder.
in a new instance of the terminal:
cd backend/java
docker build -t taskmanager-java-backend .
docker run -d -p 8081:8081 taskmanager-java-backend


-Compile the C# application and run it on  Docker.
in a new instance of the terminal: 
cd services/csharp
docker build -t taskmanager-csharp-service .
docker run -d -p 5500:80 taskmanager-csharp-service

Ensure all 4 are running in docker.

If all 4 are working and you are hosting an apache server, you can then check on each of the sites:
http://localhost:5000/tasks -> Without any tasks, should have the text Pretty pink as well as  a checkbox up top, and then []
http://localhost:8080/api.php -> Without any tasks,  should have the text Pretty pink as well as  a checkbox up top, and then []
http://localhost:8081/tasks -> Without any tasks,  should have the text Pretty pink as well as  a checkbox up top, and then [] 
http://localhost:5500/api/task -> Without any tasks,  should have the text Pretty pink as well as  a checkbox up top, and then []

// Note: the tasks for each backend are not shared. As in, if you past a task to the PHP backend, it will not be in the Java backend.


Postman section: 

Interacting with the Python Backend
Base URL: http://localhost:5000

Retrieve All Tasks
Select Method: GET
Enter URL: http://localhost:5000/tasks
Send Request: Click the Send button.
Add a New Task
Select Method: POST
Enter URL: http://localhost:5000/tasks
Set Headers: Click on the Headers tab and add:
Key: Content-Type
Value: application/json
Set Body: Click on the Body tab, select raw and JSON from the dropdown, and enter:
json
Copy code
{
  "task": "New Task"
}
Send Request: Click the Send button.
Delete a Task
Select Method: DELETE
Enter URL: http://localhost:5000/tasks/1 (replace 1 with the task ID)
Send Request: Click the Send button.


Interacting with the PHP Backend
Base URL: http://localhost:8080

Retrieve All Tasks
Select Method: GET
Enter URL: http://localhost:8080/api.php
Send Request: Click the Send button.
Add a New Task
Select Method: POST
Enter URL: http://localhost:8080/api.php
Set Headers: Click on the Headers tab and add:
Key: Content-Type
Value: application/json
Set Body: Click on the Body tab, select raw and JSON from the dropdown, and enter:
json
{
  "task": "New Task"
}
Send Request: Click the Send button.
Delete a Task
Select Method: DELETE
Enter URL: http://localhost:8080/api.php?id=1 (replace 1 with the task ID)
Send Request: Click the Send button.



Interacting with the Java Backend
Base URL: http://localhost:8081

Retrieve All Tasks
Select Method: GET
Enter URL: http://localhost:8081/tasks
Send Request: Click the Send button.
Add a New Task
Select Method: POST
Enter URL: http://localhost:8081/tasks
Set Headers: Click on the Headers tab and add:
Key: Content-Type
Value: application/json
Set Body: Click on the Body tab, select raw and JSON from the dropdown, and enter:
json
Copy code
{
  "task": "New Task"
}
Send Request: Click the Send button.
Delete a Task
Select Method: DELETE
Enter URL: http://localhost:8081/tasks/1 (replace 1 with the task ID)
Send Request: Click the Send button.


Interacting with the C# Backend
Base URL: http://localhost:5500

Retrieve All Tasks
Select Method: GET
Enter URL: http://localhost:5500/api/task
Send Request: Click the Send button.
Add a New Task
Select Method: POST
Enter URL: http://localhost:5500/api/task
Set Headers: Click on the Headers tab and add:
Key: Content-Type
Value: application/json
Set Body: Click on the Body tab, select raw and JSON from the dropdown, and enter:
json
Copy code
{
  "title": "New Task",
  "description": "Task description",
  "priority": 1,
  "dueDate": "2024-07-10"
}
Send Request: Click the Send button.
Retrieve a Specific Task
Select Method: GET
Enter URL: http://localhost:5500/api/task/1 (replace 1 with the task ID)
Send Request: Click the Send button.
Update a Specific Task
Select Method: PUT
Enter URL: http://localhost:5500/api/task/1 (replace 1 with the task ID)
Set Headers: Click on the Headers tab and add:
Key: Content-Type
Value: application/json
Set Body: Click on the Body tab, select raw and JSON from the dropdown, and enter:

json
{
  "title": "Updated Task",
  "description": "Updated description",
  "priority": 2,
  "dueDate": "2024-07-11"
}

Send Request: Click the Send button.
Delete a Task
Select Method: DELETE
Enter URL: http://localhost:5500/api/task/1 (replace 1 with the task ID)
Send Request: Click the Send button.
Mark a Task as Completed
Select Method: PUT
Enter URL: http://localhost:5500/api/task/1/complete (replace 1 with the task ID)
Send Request: Click the Send button.
Filter Tasks
Select Method: GET
Enter URL: http://localhost:5500/api/task/filter?isCompleted=true&priority=1&dueDate=2024-07-10
Send Request: Click the Send button.


