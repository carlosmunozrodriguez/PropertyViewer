# PropertyViewer

## Getting started

The solution consists in two parts:

- An ASP .NET  Core 3.1 REST API
- An Angular 10 frontend

## Prerequisites

In order to run the project the following needs to be installed

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core)
- [NodeJS](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Running the solution

After cloning the project the `/src` folder contains two projects:

- `PropertyViewer.Api`: REST API backend
- `propertyviewer-web`: SPA frontend

### Backend

1. `cd src/PropertyViewer.Api/PropertyViewer.Api`
2. `dotnet run`

The REST API will load on `https://localhost:5001`. The `properties` endpoint is `https://localhost:5001/properties`

### Frontend

1. `cd src/propertyviewer-web`
2. `npm install -g @angular/cli`
3. `npm install`
4. `ng serve --open`.

The last command will open a browser pointing to `http://localhost:4200`

## Considerations

- Frontend listens to port 4200 and backend listens to port 5001. Make sure both are available.
- The connection string in the backend is configured for Integrated Security. The database server must be configured to allow Windows Athentication and the user running the backend project needs to be in the `dbo` role. Otherwise you could change the connection string in the `appsettings.json` file.
