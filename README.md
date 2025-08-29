Overview
Minimal ASP.NET Core API offering add, list, and status update features for issues. Built with clean architecture, JWT authentication, global error handling, documentation, and testing.

Highlights
• Clean layering with Controllers, Services, SQLite (Issue, Status, IssueType, User tables)
• JWT-based authentication
• Global error handling via custom middleware for consistent error responses
• API docs in Markdown; model diagrams with PlantUML
• Unit tests covering key functionality
• Quick local setup with SQLite

Getting Started
Clone the repo, then restore packages:

dotnet restore


Environment Configuration
Create a .env file in project root (ensure it’s in .gitignore):

DefaultConnection=Data Source=issueTracker.db
JwtSettings__Secret=YourJWTSecretHere


In Program.cs, make sure to load this before building configuration:

DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();


Then fetch values via builder.Configuration.GetConnectionString("DefaultConnection") or configuration sections.

Running
Apply migrations and start the app with:

dotnet ef database update
dotnet run


Server runs at https://localhost:<port>.

Endpoints
See the included API documentation for routes on:

User registration

User login

Create issue

Get all issues

Get issue by ID

Update issue status

Project Structure

Controllers/ – API endpoints

Services/ – Business logic

Data/ – Models and EF Core setup

Middlewares/ – Global error handling

Docs/ – Markdown API docs & PlantUML diagrams

Tests/ – Unit tests (xUnit)

Testing
Run tests with:

dotnet test


Tech Stack
ASP.NET Core, Entity Framework Core, SQLite, JWT auth, xUnit, Markdown, PlantUML
