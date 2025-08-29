# Issue Tracker API

A clean, minimal **ASP.NET Core API** to add, list, and update issue statuses with JWT authentication, global error handling, docs, and tests.

---

##  Overview

This project is a minimal-viable **Issue Tracker API**, designed for clarity, testability, and maintainability:

- Clean architecture separating Controllers, Services, and Data  
- Backend storage with SQLite and normalized tables (Issue, Status, IssueType, User)  
- Secure JWT authentication  
- Custom middleware for **global error handling**—consistent, centralized error responses  
- Fully documented endpoints in Markdown and entity diagrams in PlantUML  
- Comprehensive unit tests for key behaviors  
- Easy local setup for fast onboarding  

---

##  Getting Started

### Clone & Restore

```bash
git clone [your-repo-url]
cd [project-folder]
dotnet restore
Environment Setup
Create a .env file at the project root (add to .gitignore):

env
Copy code
DefaultConnection=Data Source=issueTracker.db
JwtSettings__Secret=YourStrongJWTSecret
In Program.cs, load the environment variables before configuring:

csharp
Copy code
DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();
Access values via:

csharp
Copy code
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
var jwtSecret = builder.Configuration["JwtSettings:Secret"];
Run the App
bash
Copy code
dotnet ef database update
dotnet run
Your server will be running at https://localhost:<port>.

API Endpoints
For full request/response specs, see Docs/API_DOCUMENTATION.md. The core routes include:

POST /api/v1/auth/register — Register user

POST /api/v1/auth/login — Log in and receive JWT

POST /api/v1/issues — Create a new issue

GET /api/v1/issues — List all issues

GET /api/v1/issues/{id} — Get a specific issue

PUT /api/v1/issues/{id}/status — Update issue status

Project Structure
vbnet
Copy code
Controllers/       – API endpoints
Services/          – Business logic
Data/              – EF Core models & DbContext
Middlewares/       – Global error handling middleware
Docs/              – API documentation & PlantUML diagrams
Tests/             – Unit tests (xUnit)
Testing
Run unit tests with:

bash
Copy code
dotnet test
Tech Stack
Framework: ASP.NET Core

Database: SQLite via Entity Framework Core

Authentication: JWT Bearer Tokens

Error Handling: Custom middleware for centralized exception management

Testing: xUnit

Documentation: Markdown & PlantUML
