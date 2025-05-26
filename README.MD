# BookStore.Server

A modern ASP.NET Core Web API for managing a bookstore, built with .NET 9 and Entity Framework Core.  
Supports searching, filtering, and paginating books, with a clean architecture and unit tests.

## Features

- Search books by author, ISBN, and ownership status
- Pagination support for large datasets
- Strongly-typed models and DTOs
- OpenAPI (Swagger) documentation
- Unit tests with xUnit and EF Core InMemory

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- [React](https://es.react.dev/)
- [NodeJS](https://nodejs.org/en)
### Setup

1. **[Clone the repository:](https://github.com/luisjjavier/book-project.git)**
   
2. **Configure the database:**
   - Update the `DefaultConnection` string in `appsettings.json` as needed.
   - By default, the app uses SQL Server. You can switch to another provider in `Program.cs`.
3. **Run database migrations (if using a real database):**
   1. dotnet ef database update --project BookStore.Server
4. **Run the application:**
   1. dotnet run --project BookStore.Server
   2. the app will be available https://localhost:61101/
### Frontend
- [React 18](https://reactjs.org/)
- [TypeScript](https://www.typescriptlang.org/)
- [Vite](https://vitejs.dev/)
- [MUI (Material UI)](https://mui.com/)
- [Axios](https://axios-http.com/)

### API Usage

#### Search Books
GET /api/books/search?author=Jon&isbn=123&status=own&page=1&pageSize=10
**Query Parameters:**
- `author` (optional): Author's first or last name
- `isbn` (optional): ISBN string
- `status` (optional): Ownership status (`own`, `love`, `wanttoread`)
- `page` (optional): Page number (default: 1)
- `pageSize` (optional): Items per page (default: 10)

**Response:**
{ "data": [ { "id": 1, "title": "C# in Depth", "firstName": "Jon", "lastName": "Skeet", "isbn": "123", "ownershipStatus": "Own", "type": "Hardcover", "category": "Programming" } ], "totalCount": 1 }


### Testing

Unit tests are located in the `tests/BookStore.Server.Test` project.

To run tests:
dotnet test
### Backend-Project Structure
BookStore.Server/ 
    ├── Controllers/         # API controllers 
    ├── DbContexts/          # EF Core DbContext and configurations 
    ├── Models/              # Entity and DTO classes 
    ├── Services/            # Business logic and service interfaces 
    ├── Program.cs           # Application entry point 
    tests/ 
        └── BookStore.Server.Test/ # Unit tests