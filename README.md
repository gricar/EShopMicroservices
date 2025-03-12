# EShopMicroservices

## Overview
> There is a couple of microservices which implemented e-commerce modules over Catalog, Basket, Discount and Ordering microservices with NoSQL (DocumentDb, Redis) and Relational databases (PostgreSQL, Sql Server) with communicating over RabbitMQ Event Driven Communication and using Yarp API Gateway.
These microservices data’s will store NoSQL and Relational databases with communicating over gRPC and RabbitMQ Event Driven Communication and also using Yarp API Gateway for client operations.

![image](https://github.com/user-attachments/assets/0ab3e22a-4f9d-4e55-a0c5-cfc9b389d03b)


### Architectures of microservices

1. **Catalog microservice**
   
   ![image](https://github.com/user-attachments/assets/e70b81a9-ee8d-4fa1-aedd-df92af4e912b)

   - ASP.NET Core Minimal APIs and latest features of .NET8 and C# 12
   - Vertical Slice Architecture implementation with Feature folders and single .cs file includes different classes in one file
   - CQRS implementation using MediatR library
   - CQRS Validation Pipeline Behaviors with MediatR and FluentValidation
   - Use Marten library for .NET Transactional Document DB on PostgreSQL
   - Use Carter for Minimal API endpoint definition
   - Cross-cutting concerns Logging, Global Exception Handling and Health Checks
   - Implement Dockerfile and docker-compose file for running Product microservice and PostgreSQL database in Docker environment
    
2. **Basket microservice**
   
   ![image](https://github.com/user-attachments/assets/efd2dbb9-9061-4805-bed6-7a1093845916)

   - All above Catalog Microservice items into Basket Microservice
   - ASP.NET 8 Web API application, Following REST API principles, CRUD
   - Using Redis as a Distributed Cache over basketdb
   - Implements Proxy, Decorator and Cache-aside patterns
   - Consume Discount Grpc Service for inter-service sync communication to calculate product final price
   - Publish BasketCheckout Queue with using MassTransit and RabbitMQ
   - Containerize Basket Microservices with Redis and PostgreSQL database
    
3. **Discount microservice**
   
    ![image](https://github.com/user-attachments/assets/ded434e3-fe9a-4083-8365-38687108fdf0)

   - ASP.NET Grpc Server application
   - Build a Highly Performant inter-service gRPC Communication with Basket Microservice
   - Exposing Grpc Services with creating Protobuf messages
   - Entity Framework Core ORM — SQLite Data Provider and Migrations to simplify data access and ensure high performance
   - N-Layer Architecture implementation
   - SQLite database connection and containerization

4. **Ordering Microservice**
   
    ![image](https://github.com/user-attachments/assets/1342a9f0-86e5-4f2f-8f8b-44658e5f4f7e)

   - ASP.NET Core Web Minimal APIs for building fast HTTP APIs-fully functioning REST endpoints for CRUD operations
   - Implementing DDD, CQRS, and Clean Architecture with using Best Practices (SOLID Principles, Dependency Injection)
   - Developing CQRS with using MediatR, FluentValidation and Mapster packages
   - Raise and handle Domain Events & Integration Events
   - Consuming RabbitMQ BasketCheckout event queue with using MassTransit-RabbitMQ Configuration
   - SqlServer database connection and containerization
   - Using Entity Framework Core ORM and auto migrate to SqlServer when application startup

5. **Microservices Async Communication w/ RabbitMQ & MassTransit**
   
  ![image](https://github.com/user-attachments/assets/b03ce8df-28ca-4ec4-a899-1cbb4d3a9eb1)

   - Async Microservices Communication with RabbitMQ Message-Broker Service
   - Using RabbitMQ Publish/Subscribe Topic Exchange Model
   - Using MassTransit for abstraction over RabbitMQ Message-Broker system
   - Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices
   - Create RabbitMQ EventBus.Messages library and add references Microservices
   - Containerize RabbitMQ Message Queue system with Basket and Ordering microservices using Docker Compose

6. **Yarp API Gateway Microservice**

  ![image](https://github.com/user-attachments/assets/82e43171-a0f3-45d0-8af6-55359072c72a)

   - Develop API Gateways with Yarp Reverse Proxy applying Gateway Routing Pattern
   - Yarp Reverse Proxy Configuration; Route, Cluster, Path, Transform, Destinations
   - Rate Limiting with FixedWindowLimiter on Yarp Reverse Proxy Configuration
   - Containerize YarpApiGateway Microservices using Docker Compose

   
### Patterns, Principles, Libraries, Communications, Best Practices

- Implement different architecture styles: DDD, Vertical Slice and Clean Architecture
- Implement different patterns: SOLID Principles, Dependency Injection principles, CQRS and Mediator Pattern, Options Pattern, Proxy and Decorator Pattern, Publish-Subscribe Pattern, Api Gateway Pattern, Cache-aside Pattern
- Implements different Database types: NoSQL and Relational: Transactional DocumentDB, PostgreSQL, SQLite, SQL Server, Distributed Caches (Redis) and Message brokers async communication with RabbitMQ and Masstransit library
- Use Popular .NET libraries: Carter, Marten, MediatR, FluentValidation, Mapster, MassTransit, EF Core, Refit
- Implement different communication styles: Sync and Async communication between microservices
- Build a Highly Performant inter-service gRPC Communication with Discount and Basket Microservice
- Microservices Async Communication Publish Subscribe Pattern w/ RabbitMQ & MassTransit for Checkout Basket Between Basket-Ordering Microservices
- Building API Gateways with Yarp Reverse Proxy applying Gateway Routing Pattern

## Run The Project
You will need the following tools:
- Visual Studio 2022
- .Net Core 8 or later
- Docker Desktop

> [!TIP]
> Once Docker for Windows is installed, go to the Settings > Advanced option, from the Docker icon in the system tray, to configure the minimum amount of memory and CPU like so: Memory: 4 GB and CPU: 2

Installing
Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)

1. Clone the repository
2. At the root directory of solution, select docker-compose and Set a startup project. Run docker-compose without debugging on visual studio.
3. Or you can go to root directory which include docker-compose.yml files, run below command:
   
``docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d``

5. Wait for docker compose all microservices. That’s it! (some microservices need extra time to work so please wait if not worked in first shut)
6. Launch Shopping Web UI -> https://localhost:6065 in your browser to view index page. You can use Web project in order to call microservices over Yarp API Gateway. When you checkout the basket you can follow queue record on RabbitMQ dashboard.
