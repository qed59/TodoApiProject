# Todo Web API

A minimal ASP.NET Core Web API for managing TODO items (in-memory).

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)

## Run the API

```bash
# Clone and enter the project folder
git clone https://github.com/qed59/TodoApiProject.git
cd TodoApiProject/src/Todoapi/

# Restore packages
dotnet restore

# Run (uses the "https" launch profile)
dotnet run --launch-profile "https"
