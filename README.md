# PremiersPas 🚀

## Project Title & Badges

[![Stars](https://img.shields.io/github/stars/Mister-Z-coder/PremiersPas?style=social)](https://github.com/Mister-Z-coder/PremiersPas/stargazers)
[![Forks](https://img.shields.io/github/forks/Mister-Z-coder/PremiersPas?style=social)](https://github.com/Mister-Z-coder/PremiersPas/network/members)
[![Primary Language](https://img.shields.io/github/languages/top/Mister-Z-coder/PremiersPas)](https://github.com/Mister-Z-coder/PremiersPas)
[![Last Commit](https://img.shields.io/github/last-commit/Mister-Z-coder/PremiersPas)](https://github.com/Mister-Z-coder/PremiersPas/commits/main)

## Description 📝

This project, named 'PremiersPas,' is a foundational ASP.NET Core MVC application with a Model-View-Controller (MVC) architecture. It comprises two primary components: a Front-end MVC project (`FrontendMVC`) and a Back-end Web API project (`BackendAPI`), both residing within the same solution. The application appears to manage data related to schools, students, academic years and inscriptions. The Backend API handles data management, while the Frontend MVC provides the user interface.

## Table of Contents

1.  [Features](#features)
2.  [Tech Stack](#tech-stack)
3.  [Project Structure](#project-structure)
4.  [Backend API Details](#backend-api-details)
5.  [Frontend MVC Details](#frontend-mvc-details)
6.  [Installation](#installation)
7.  [Usage](#usage)
8.  [API Reference](#api-reference)
9.  [Contributing](#contributing)
10. [License](#license)
11. [Important Links](#important-links)
12. [Footer](#footer)

## Features ✨

Based on the code analysis, the 'PremiersPas' project includes the following features:

*   **MVC Architecture**: Implements the Model-View-Controller architectural pattern, separating concerns for maintainability and scalability.
*   **Backend API**: Provides a RESTful API for managing school-related data, using ASP.NET Core Web API.
*   **Frontend Interface**: Offers a user interface for interacting with the data through the ASP.NET Core MVC project.
*   **CRUD Operations**: Supports Create, Read, Update, and Delete operations for managing entities like schools (`Ecole`), students (`Eleve`), academic years (`AnneeScolaire`), and registrations (`Inscription`).
*   **Data Transfer Objects (DTOs)**: Uses DTOs to encapsulate data transferred between the API and the frontend.
*   **Exception Handling**: Implements custom exception handling middleware for consistent error responses.
*   **Data Persistence**: Utilizes Entity Framework Core for database interactions, with migration support.
*   **Pagination Support**: Includes pagination logic for handling large datasets efficiently.
*   **AutoMapper Integration**: Uses AutoMapper for object-to-object mapping between models and DTOs.
*   **Dependency Injection**: Leverages ASP.NET Core's built-in dependency injection for managing services and repositories.

## Tech Stack 💻

*   **Primary Language**: C#
*   **Framework**: ASP.NET Core MVC, ASP.NET Core Web API
*   **Database**: Entity Framework Core (for data access)
*   **Languages**: JSON, CSS, JavaScript
*   **Libraries**: TypeScript, Python, JQuery, JQuery Validation, Bootstrap

## Project Structure 📂

The project is structured as follows:

```
PremiersPas.sln (Solution File)
├── BackendAPI (ASP.NET Core Web API Project)
│   ├── Controllers
│   │   ├── AnneeScolaireController.cs
│   │   ├── EcoleController.cs
│   │   ├── EleveController.cs
│   │   └── InscriptionController.cs
│   ├── DTOs
│   │   ├── Annee_ScolaireDto.cs
│   │   ├── BaseDto.cs
│   │   ├── EcoleDto.cs
│   │   ├── EleveDto.cs
│   │   └── InscriptionDto.cs
│   ├── Data
│   │   └── ApplicationDbContext.cs
│   ├── Exceptions
│   │   ├── BaseException.cs
│   │   ├── ExceptionMiddleware.cs
│   │   ├── InvalidInputException.cs
│   │   └── NotFoundException.cs
│   ├── Mapper
│   │   └── MappingProfile.cs
│   ├── Migrations
│   │   └── (Migration Files).cs
│   ├── Models
│   │   ├── Annee_Scolaire.cs
│   │   ├── BaseEntity.cs
│   │   ├── Ecole.cs
│   │   ├── Eleve.cs
│   │   └── Inscription.cs
│   ├── Repositories
│   │   ├── Implementations
│   │   │   ├── AnneeScolaireRepository.cs
│   │   │   ├── BaseRepository.cs
│   │   │   ├── EcoleRepository.cs
│   │   │   ├── EleveRepository.cs
│   │   │   └── InscriptionRepository.cs
│   │   └── Interfaces
│   │       ├── IAnneeScolaireRepository.cs
│   │       ├── IEcoleRepository.cs
│   │       ├── IEleveRepository.cs
│   │       ├── IInscriptionRepository.cs
│   │       └── IRepository.cs
│   ├── Services
│   │   ├── Implementations
│   │   │   ├── AnneScolaireService.cs
│   │   │   ├── BaseService.cs
│   │   │   ├── EcoleService.cs
│   │   │   ├── EleveService.cs
│   │   │   ├── InscrpitionService.cs
│   │   │   └── UriService.cs
│   │   └── Interfaces
│   │       ├── IAnneeScolaireService.cs
│   │       ├── IEcoleService.cs
│   │       ├── IEleveService.cs
│   │       ├── IInscriptionService.cs
│   │       ├── IService.cs
│   │       └── IUriService.cs
│   ├── Wrappers
│   │   ├── Filter
│   │   │   └── PaginationFilter.cs
│   │   ├── Helpers
│   │   │   ├── EntityKeyHelper.cs
│   │   │   └── PaginationHelper.cs
│   │   └── Response
│   │       ├── PagedResponse.cs
│   │       └── Response.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── BackendAPI.csproj
│
└── FrontendMVC (ASP.NET Core MVC Project)
    ├── Controllers
    │   ├── EcolesController.cs
    │   └── HomeController.cs
    ├── Mapper
    │   └── MappingProfile.cs
    ├── Models
    │   ├── DTOs
    │   │   ├── AnneeScolaireDto.cs
    │   │   ├── BaseDto.cs
    │   │   ├── EcoleDto.cs
    │   │   ├── EleveDto.cs
    │   │   └── InscriptionDto.cs
    │   ├── Filters
    │   │   └── PaginationFilter.cs
    │   ├── ViewModels
    │   │   ├── AnneeScolaireViewModel.cs
    │   │   ├── EcoleViewModel.cs
    │   │   ├── EleveViewModel.cs
    │   │   └── InscriptionViewModel.cs
    │   └── Wrappers
    │       ├── PagedResponse.cs
    │       └── Response.cs
    ├── Services
    │   ├── Factories
    │   │   ├── HttpClientFactoryService.cs
    │   │   └── IHttpClientFactoryService.cs
    │   ├── Implementations
    │   │   ├── AnneeScolaireApiService.cs
    │   │   ├── BaseApiService.cs
    │   │   ├── EcoleApiService.cs
    │   │   ├── EleveApiService.cs
    │   │   └── InscriptionApiService.cs
    │   └── Interfaces
    │       ├── IAnneeScolaireApiService.cs
    │       ├── IApiService.cs
    │       ├── IEcoleApiService.cs
    │       ├── IEleveApiService.cs
    │       └── IInscriptionApiService.cs
    ├── Views
    │   ├── Ecoles
    │   │   ├── Create.cshtml
    │   │   ├── Delete.cshtml
    │   │   ├── Details.cshtml
    │   │   ├── Edit.cshtml
    │   │   └── Index.cshtml
    │   ├── Home
    │   │   ├── Index.cshtml
    │   │   └── Privacy.cshtml
    │   ├── Shared
    │   │   ├── Error.cshtml
    │   │   ├── _Layout.cshtml
    │   │   └── _ValidationScriptsPartial.cshtml
    │   ├── _ViewImports.cshtml
    │   └── _ViewStart.cshtml
    ├── wwwroot
    │   ├── css
    │   │   └── site.css
    │   ├── js
    │   │   └── site.js
    │   └── lib
    │       ├── bootstrap
    │       ├── jquery
    │       ├── jquery-validation
    │       └── jquery-validation-unobtrusive
    ├── appsettings.json
    ├── appsettings.Development.json
    └── FrontendMVC.csproj
```

## Backend API Details ⚙️

The `BackendAPI` project is an ASP.NET Core Web API responsible for handling data operations. It exposes endpoints for managing schools, students, academic years, and inscriptions. Key components include:

*   **Controllers**: `AnneeScolaireController`, `EcoleController`, `EleveController`, and `InscriptionController` manage HTTP requests and responses for their respective entities.
*   **Data**: `ApplicationDbContext` configures Entity Framework Core to interact with the database.
*   **Models**: Defines the data models (`Annee_Scolaire`, `Ecole`, `Eleve`, `Inscription`) that represent the database schema.
*   **Repositories**: Provides an abstraction layer for data access, separating the data access logic from the service layer.
*   **Services**: Contains the business logic for the application, orchestrating data access and validation.

## Frontend MVC Details 🖥️

The `FrontendMVC` project is an ASP.NET Core MVC application that provides the user interface. It consumes the `BackendAPI` to display and manage data. Key components include:

*   **Controllers**: `EcolesController` and `HomeController` handle user interactions and manage the views.
*   **Models**: Defines the data models and view models used in the application.
*   **Services**: `ApiService` implementations handle communication with the `BackendAPI`.
*   **Views**: `.cshtml` files define the user interface and display data to the user.

## Installation 🛠️

1.  **Clone the repository**:

    ```bash
    git clone https://github.com/Mister-Z-coder/PremiersPas.git
    cd PremiersPas
    ```

2.  **Navigate to the project directory**.

    ```bash
    cd PremiersPas
    ```

3.  **Restore NuGet packages**:

    ```bash
    dotnet restore
    ```

4.  **Apply Database Migrations**:

    ```bash
    cd BackendAPI
    dotnet ef database update
    ```

5.  **Build the solution**:

    ```bash
    dotnet build
    ```

## Usage 🖱️

1.  **Run the Backend API**:

    ```bash
    cd BackendAPI
    dotnet run
    ```

2.  **Run the Frontend MVC application**:

    ```bash
    cd FrontendMVC
    dotnet run
    ```

3.  **Access the application**: Open your web browser and navigate to the URL where the Frontend MVC application is running (e.g., `https://localhost:5001`).

This project can be used for:

*   **School Management**: Managing schools, students, and their associated data.
*   **Educational Registrations**: Handling student registrations and academic year management.
*   **Learning ASP.NET Core MVC**: As a practical example for understanding the MVC architecture and ASP.NET Core development.

## API Reference ℹ️

The Backend API provides the following endpoints:

*   `/api/AnneeScolaire`: Manages academic years.
*   `/api/Ecole`: Manages school data.
*   `/api/Eleve`: Manages student information.
*   `/api/Inscription`: Manages student registrations.

Refer to the controller files (`AnneeScolaireController.cs`, `EcoleController.cs`, `EleveController.cs`, `InscriptionController.cs`) in the `BackendAPI/Controllers` directory for detailed information on available endpoints and their request/response formats.

## Contributing 🤝

Contributions are welcome! Here are the steps to contribute:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with descriptive messages.
4.  Push your changes to your fork.
5.  Submit a pull request to the main repository.

## License 📜

No license provided.

## Important Links 🔗

*   **Repository URL**: [https://github.com/Mister-Z-coder/PremiersPas](https://github.com/Mister-Z-coder/PremiersPas)

## Footer 👣

*   **Repository**: [PremiersPas](https://github.com/Mister-Z-coder/PremiersPas)
*   **Author**: Mister-Z-coder
*   **Contact**: (No contact information provided)

⭐️ Like, fork, and contribute to the repository! Raise issues and help improve the project.


---
**<p align="center">Generated by [ReadmeCodeGen](https://www.readmecodegen.com/)</p>**
