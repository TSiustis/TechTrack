
# TechTrack

TechTrack is an app that tracks the equipment assigned to users. It was made to showcase Clean Architecture, CQRS principles and the newest Blazor features.

## Features

-   **TechTrack.Api**: Backend API to handle all data processing and business logic.
-   **TechTrack.Application**: Core application logic and services.
-   **TechTrack.Common**: Shared utilities and helper functions.
-   **TechTrack.Domain**: Domain models and entities.
-   **TechTrack.Persistence**: Data persistence and repository implementations.
-   **TechTrack.UnitTests**: Unit tests for ensuring code quality.
-   **Techtrack.Ui**: Frontend user interface built with Blazor.

## Technologies

-   **C#**: Backend development.
-   **Blazor**: Frontend development.

## Getting Started

1.  Clone the repository:
    `git clone https://github.com/TSiustis/TechTrack.git` 
    
2.  Navigate to the project directory and open the solution file `TechTrack.sln` in Visual Studio.
3.  Run the update database commands in Package Manager Console:
      Update-Database -context ReadDbContext
      Update-Database -context WriteDbContext.
5.  Build and run the solution.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.
