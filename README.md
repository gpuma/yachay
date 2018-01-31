# yachay
Virtual classroom written on ASP.NET Core and Vue.js

# some steps
- To drop DB: `dotnet ef drop database`
- To create migrations for the DB: `dotnet ef migrations add InitialCreate`
  - (not necessary if migrations are included in the repo)
- To apply migrations (create DB): `dotnet ef database update`