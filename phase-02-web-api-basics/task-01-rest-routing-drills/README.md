# Task 01: REST Routing Drills

This folder contains the setup for Web API routing drills in ASP.NET Core.

## Project Structure
- `ApiRoutingDrills/`: The ASP.NET Core Web API project.
  - `Controllers/`: Contains the API endpoints organized by domain.
    - `HealthController.cs`: Health check endpoint.
    - `ToolsController.cs`: Endpoints demonstrating route parameters, query strings, request headers, and status codes.
    - `CalculatorController.cs`: Mathematical calculation endpoints.
    - `NotesController.cs`: A CRUD API representation for notes.
  - `DTOs/`: Data Transfer Objects used by the endpoints.
  - `Services/`: Business logic services.

## Drills Included
- Drill 01: Health Check Endpoint
- Drill 02: Route Parameter Echo
- Drill 03: Query String Calculator
- Drill 04: Temperature Conversion API
- Drill 05: Grade API
- Drill 06-12: Notes CRUD, Pagination, and Search
- Drill 13: Header Reader Endpoint
- Drill 14: Status Code Practice
- Drill 15: Standard Error Shape
