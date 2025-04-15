# Clean-CRUD
A sample simplified C# full-stack application with a backend __ASP.NET Core__ project and a frontend __Angular__ project.

## Technology Stack
  -	ASP.NET Core -v8
  - Entity Framework Core -v8
  - DDD (Domain-Driven Design)
  - TDD (Test-Driven Development)
  - BDD (Behavior-driven Development)
  - Clean Architecture
  - Clean Code
  - Repository Design Pattern
  - CQRS Design Pattern
  - Mediator Design pattern
  - PostgreSQL Database
  - Angular v19
  - Angular Material v19
  - Docker

#### Nuget Packages
  - __xUnit__ for unit, integration and acceptance testing
  - __NSubstitute__ for mocking
  - __MediatR__ for implementing mediator pattern
  - __FluentValidation__ for server-side validation
  - __AutoMapper__ for object mapping
  - __Angular Material__ for implementing user-interface


This repository is intended for demonstrating best practices in software development. In real-world applications, these practices should be selected based on the specific requirements of each project.


      
## Run with Docker

#### 1. Start with Docker compose

Run the following command in project directory:

```
docker-compose up -d
```

Docker compose in this application includes 4 services:

- __ASP.NET Core API__ will be listening at `http://localhost:5000`

- __Angular Frontend__ will be listening at `http://localhost:8080`

- __Postgres database__ will be listening at `http://localhost:5432`
