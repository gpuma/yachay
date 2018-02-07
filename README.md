# Yachay
Virtual classroom SPA written on ASP.NET Core, Vue.js and Typescript.

## Demo
- [Video demo](https://youtu.be/66J8GnKnnmg)

## Main features
- Creating students
- Creating units
- Enrolling students to units
- Grading students

## Requirements:
- Windows (due to ´LocalDB´)
- [ASP.NET Core](https://www.microsoft.com/net/learn/get-started/)
- [Node.js and npm](https://www.npmjs.com/get-npm)
- ASP.NET Core SpaTemplates: `dotnet new --install Microsoft.AspNetCore.SpaTemplates::*`


## Building and running the project
- Clone the repo: `git clone http://github.com/gpuma/yachay`
- Install Node packages: `npm install`
- Restore Nuget Packages: `dotnet restore`
- Create the SQL database: `dotnet ef database update`
- Run the project: `dotnet run`

## Notes
- I recommend using [Visual Studio Code](https://code.visualstudio.com/) for editing.

## TODO
- Migrate from LocalDB to a cross-platform database