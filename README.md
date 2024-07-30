# Community Event Planner

## Overview

The Community Event Planner application is designed to help users create and discover Everflow community events. This README outlines the key features, architectural approach, and the considerations for scalability and security implemented in the application.

## Key Features

1. **Event Creation and Discovery**: Users can create events and view a list of upcoming events.
2. **User Registration and Login**: Simple registration and login process, including authentication with JWT.

**Note**: Did not complete the create events front end 

## Architectural Approach

The application is built using the following architectural patterns and practices:

### Clean Architecture

Clean Architecture ensures the system is maintainable, testable, and scalable. This architecture separates the core business logic from external concerns, allowing each component to be developed and tested independently.

### CQRS Pattern

The Command Query Responsibility Segregation (CQRS) pattern is used to separate read and write operations. This separation helps in optimizing performance and scaling each part of the application independently.

### Repository Pattern

The repository pattern abstracts the data access layer, providing a clean separation between the business logic and data access code. This abstraction allows for easier testing and the flexibility to switch data storage mechanisms if needed.

### Unit of Work Pattern

The Unit of Work pattern is used to maintain a list of objects affected by a business transaction and coordinate the writing out of changes and the resolution of concurrency problems. It allows for a single point of interaction with multiple repositories, ensuring all changes are committed as a single transaction.

## Scalability Considerations

1. **Clean Architecture**: Promotes maintainability and scalability by separating concerns.
2. **CQRS Pattern**: Allows independent scaling of read and write operations.
3. **Repository Pattern**: Facilitates optimization of data access strategies.
4. **Unit of Work Pattern**: Ensures transactional integrity and efficient management of multiple repositories.
5. **Asynchronous Processing**: Efficiently handles I/O-bound operations.

## Security Considerations

1. **ASP.NET Identity**: Manages user authentication and authorization securely.
2. **JWT (JSON Web Tokens)**: Ensures secure and stateless communication between client and server.
3. **Role-Based Access Control (RBAC)**: Manages user permissions effectively.
4. **Input Validation with FluentValidation**: Prevents common security vulnerabilities through rigorous input validation.
6. **Global Exception Handling**: Manages unexpected errors gracefully and securely.

## Technologies Used

- **Backend Framework**: .NET 8 or higher
- **Frontend Framework**: Blazor
- **Database**: SQL Server
- **Authentication**: ASP.NET Identity, JWT
- **Validation**: FluentValidation
- **Testing**: xUnit, Moq, In-memory database for integration tests

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio or VS Code


### Setup Instructions

1. **Clone the repository**:
   ```sh
   git clone https://github.com/ulomaramma/CommunityEventPlanner.API.git
   cd CommunityEventPlanner.API
2. **Configure the database connection**:
   The application uses LocalDB by default. You can update the connection string in appsettings.json.
3. **Run database migrations**: 
   ```sh
   dotnet ef database update
4. **Seed the database**:
   The application seeds data for a default user and events when the API project is started. If you encounter any issues with seeding data, please run migrations and update database as stated in number 3.

5. **Build and run the application**:
   ```sh
   dotnet build
   dotnet run

6. **Set up the solution to start multiple projects**:
To fully test the project, set the solution properties to start both the **CommunityEventPlanner.API** and **CommunityEventPlanner.Client** projects.

## Brief API Documentation
### Authentication

### Register a new user
**Endpoint**: POST /api/auth/sign-up

Request Body:
```json
{
  "email": "newuser@example.com",
  "password": "Password123!",
  "firstName": "New",
  "lastName": "User"
}
```

Response:
```json
{
  "success": true,
  "code": 201,
  "jwtToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im5ld3VzZXJAZXhhbXBsZS5jb20iLCJzdWIiOiI5Njg3YTdmMy1jZTBjLTQwZGYtOWJhOC04MWU4OGFiNmE3MDAiLCJuYW1lIjoibmV3dXNlckBleGFtcGxlLmNvbSIsInJvbGVzIjoiVXNlciIsImV4cCI6MTcyMjMyMzIzNiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE4NiIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcwOTAifQ.YPnALNxzeRo93jigjstnDrCe6xzee8aSnyVG6G-I-mI",
  "message": "User Registered Sucessfully"
}
```
### Login a user
**Endpoint**: POST /api/auth/login

Request Body:
```json
{
  "email": "newuser@example.com",
  "password": "Password123!",
}
```
Response:
```json
{
  "success": true,
  "code": 200,
  "jwtToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImN5bmRpYmlsb0BnbWFpbC5jb20iLCJzdWIiOiI2OTQ1MThjNC04ZWE1LTRkNzUtOWRjZC05N2U4NzFkZWFjZDIiLCJuYW1lIjoiY3luZGliaWxvQGdtYWlsLmNvbSIsImV4cCI6MTcyMjMyNDQwMiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE4NiIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjcwOTAifQ.n3gCT-YL4WVJSVJvu4JmZKUj2QBmzsd4U4aO_9qQM88",
  "message": "User Logged in Sucessfully."
}
```
Events
Create a new event
Endpoint: POST /api/events

### Headers:
**Authorization**: Bearer {your-jwt-token}

### Request Body:
```json
{
  "title": "Upcoming Event 2",
  "description": "This event is also in the future",
  "startDate": "2024-08-10",
  "endDate": "2024-08-11",
  "startTime": "09:00:00",
  "endTime": "17:00:00",
  "location": "string",
  "isPhysical": true,
  "accessLink": "https://example.com",
  "imageUrl": "",
  "isFree": true,
  "cost": 50,
  "capacity": 100,
  "eventCategoryId": 1,
  "userId": "9687a7f3-ce0c-40df-9ba8-81e88ab6a700",
  "eventType": 1,
  "eventStatus": 1
}
```
Response Body:
```json
{
  "message": "Event Created Successfully",
  "success": true,
  "code": 201,
  "data": {
    "eventId": 5,
    "title": "Upcoming Event 2",
    "description": "This event is also in the future",
    "startDate": "2024-08-10T00:00:00",
    "endDate": "2024-08-11T00:00:00",
    "startTime": "09:00:00",
    "endTime": "17:00:00",
    "location": "string",
    "isPhysical": true,
    "accessLink": "https://example.com",
    "imageUrl": "",
    "isFree": true,
    "cost": 50,
    "capacity": 100
  }
}
```
Get upcoming events
Endpoint: GET /api/events/upcoming

### Headers:
**Authorization**: Bearer {your-jwt-token}
Response Body:
```json
{
  "message": null,
  "success": true,
  "code": 200,
  "data": [
    {
      "eventId": 1,
      "title": "Tech Conference 2024",
      "description": "Annual tech conference covering the latest in technology.",
      "startDate": "2024-08-22T00:00:00",
      "endDate": "2024-09-19T00:00:00",
      "startTime": "09:00:00",
      "endTime": "18:00:00",
      "location": "New York Convention Center",
      "isPhysical": true,
      "accessLink": "",
      "imageUrl": "",
      "isFree": false,
      "cost": 299.99,
      "capacity": 500
    },
    {
      "eventId": 2,
      "title": "Online Workshop on AI",
      "description": "Interactive online workshop on artificial intelligence.",
      "startDate": "2024-08-07T00:00:00",
      "endDate": "2024-09-08T00:00:00",
      "startTime": "08:00:00",
      "endTime": "17:00:00",
      "location": "Online",
      "isPhysical": false,
      "accessLink": "https://meet.google.com/oaf-ernz-mxi?hs=122&authuser=0",
      "imageUrl": "",
      "isFree": true,
      "cost": 0,
      "capacity": 1000
    },
    {
      "eventId": 3,
      "title": "Sample Event",
      "description": "This is a sample event",
      "startDate": "2024-08-01T00:00:00",
      "endDate": "2024-08-02T00:00:00",
      "startTime": "09:00:00",
      "endTime": "17:00:00",
      "location": "Sample Location",
      "isPhysical": true,
      "accessLink": "",
      "imageUrl": "https://example.com/image.jpg",
      "isFree": true,
      "cost": 0,
      "capacity": 100
    }
    
  ]
}
```
