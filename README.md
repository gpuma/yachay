# yachay
Virtual classroom written on ASP.NET Core and Vue.js

# Functionality
You can:
- Create students
- Create units
- Enroll students to units
- Grade enrollments

# Requirements:
- [ASP.NET Core](https://www.microsoft.com/net/learn/get-started/)
- [Node.js and npm](https://www.npmjs.com/get-npm)
- ASP.NET Core SpaTemplates: `dotnet new --install Microsoft.AspNetCore.SpaTemplates::*
`

# Notes
- I recommend using [Visual Studio Code](https://code.visualstudio.com/) for editing.

# Building and running the project
- Clone the repo: `git clone http://github.com/gpuma/yachay`
- Install Node packages: `npm install`
- Restore Nuget Packages: `dotnet restore`
- Create the SQL database: `dotnet ef database update`
- Run the project: `dotnet run`

## wot


- To drop DB: `dotnet ef drop database`
- To create migrations for the DB: `dotnet ef migrations add InitialCreate`
  - (not necessary if migrations are included in the repo)
- To apply migrations (create DB): `dotnet ef database update`

## Troubleshooting
#### Getting `Build failed` errors
- dotnet ef migrations list -v
#### Getting a `Database already exists` error
-
