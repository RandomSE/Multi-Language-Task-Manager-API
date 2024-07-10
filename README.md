# Multi-Language-Task-Manager-API
# Multi-Language Task Manager API

## Overview

The Multi-Language Task Manager API is a project that showcases the development of RESTful APIs using multiple programming languages and frameworks. It includes implementations in Python, PHP, Java, and C#.

## Features

- Task management (Create, Retrieve, Delete tasks)
- API implementations in Python (Flask), PHP, Java (Spring Boot), and C# (ASP.NET Core)
- Dockerized services for easy deployment

## Technologies

- Python
- PHP
- Java
- C#
- Docker

## Usage

### Running the Services

1. **Python**:
    ```sh
    cd backend/python
    docker build -t taskmanager-python-backend .
    docker run -d -p 5000:5000 taskmanager-python-backend
    ```

2. **PHP**:
    ```sh
    cd backend/php
    docker build -t taskmanager-php-backend .
    docker run -d -p 8080:80 taskmanager-php-backend
    ```

3. **Java**:
    ```sh
    cd backend/java
    docker build -t taskmanager-java-backend .
    docker run -d -p 8081:8081 taskmanager-java-backend
    ```

4. **C#**:
    ```sh
    cd backend/csharp
    docker build -t taskmanager-csharp-service .
    docker run -d -p 5500:80 taskmanager-csharp-service
    ```

## API Endpoints

### Python
- **GET /tasks**
- **POST /tasks**
- **DELETE /tasks/{id}**

### PHP
- **GET /api.php**
- **POST /api.php**
- **DELETE /api.php?id={id}**

### Java
- **GET /tasks**
- **POST /tasks**
- **DELETE /tasks/{id}**

### C#
- **GET /api/task**
- **POST /api/task**
- **GET /api/task/{id}**
- **PUT /api/task/{id}**
- **DELETE /api/task/{id}**
- **PUT /api/task/{id}/complete**
- **GET /api/task/filter**

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
