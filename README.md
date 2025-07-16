# InmobiliariaAndes

A modern real estate management API built with **.NET 8** and C# 12, following clean architecture principles. This project is designed for scalability, maintainability, and ease of deployment in both local and production environments.

---

## Architecture Overview

The solution is organized into multiple layers:

- **API Layer (`InmobiliariaAndes.API`)**  
  Exposes RESTful endpoints, handles HTTP requests, and manages application startup and configuration.

- **Application Layer (`InmobiliariaAndes.Application`)**  
  Contains business logic, service registration, and application-specific extensions.

- **Infrastructure Layer (`InmobiliariaAndes.Infrastructure`)**  
  Handles data access, external integrations, and persistence.

### Flow

1. **Startup**  
   The application starts in `Program.cs`, where it configures services, middleware, and controllers.

2. **Configuration**  
   - Reads configuration from `appsettings.json`, `appsettings.Local.json`, `.env`, or `Local.env` files.
   - Environment variables are loaded (see below).

3. **Dependency Injection**  
   - `AddApplicationServices` extension method registers application services and the database context.
   - The connection string is selected based on the environment:
     - If `Environment=Local`, it uses the value from environment variables (typically loaded from `Local.env`).
     - Otherwise, it uses the value from configuration files.

4. **Request Handling**  
   - API controllers receive HTTP requests, invoke application services, and return responses.

---

## Environment Configuration

The project supports flexible configuration for different environments:

- **`.env`**  
  Used for production or general environment variables. Place this file at the root of the API project.  

- **`Local.env`**  
Used for local development. Place this file at the root of the API project.  

- **`appsettings.Local.json`**  
Used for local configuration overrides. This file is loaded automatically when running locally.

- **`DotEnv.cs`**  
Utility class that loads environment variables from `.env` or `Local.env` files at startup.

**Note:** 
- The application prioritizes `Local.env` when `Environment=Local` is set.
- Environment variables can override values in `appsettings.json` and `appsettings.Local.json`.

---

## Running Locally

1. Create a `Local.env` file with your local settings.
2. Run the API project. The application will load environment variables and use the local connection string.
3. Access Swagger UI at `/swagger` for API documentation.

---

## Testing & Coverage

- Unit tests are located in the corresponding test projects.
- Code coverage is enforced via CI (see `.github/workflows/ci.yml`), requiring a minimum of 60% coverage for pull requests.

---

## Deployment

- For production, use a `.env` file with the appropriate settings.
- The project is ready for containerization (see `Dockerfile`).
