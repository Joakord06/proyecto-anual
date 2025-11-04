# LayeredApp

## Overview
LayeredApp is a software application structured in a layered architecture, consisting of three main layers: Presentation, Business, and Data. This architecture promotes separation of concerns, making the application easier to manage, test, and scale.

## Project Structure
The project is organized as follows:

- **Presentation Layer**: Contains the user interface and handles user interactions.
  - `LayeredApp.Presentation.csproj`: Project file for the Presentation layer.
  - `Program.cs`: Entry point of the application.
  - `Startup.cs`: Configures services and the request pipeline.
  - `appsettings.json`: Configuration settings for the application.
  - `Controllers/HomeController.cs`: Controller for handling home page requests.

- **Business Layer**: Contains the business logic and rules of the application.
  - `LayeredApp.Business.csproj`: Project file for the Business layer.
  - `Interfaces/IUserService.cs`: Interface defining user-related operations.
  - `Services/UserService.cs`: Implementation of user-related business logic.

- **Data Layer**: Responsible for data access and management.
  - `LayeredApp.Data.csproj`: Project file for the Data layer.
  - `Entities/User.cs`: Represents the user entity.
  - `Repositories/UserRepository.cs`: Contains methods for data access.

## Setup Instructions
1. Clone the repository to your local machine.
2. Open the solution file `LayeredApp.sln` in your preferred IDE.
3. Restore the NuGet packages for all projects.
4. Configure the database connection in `appsettings.json`.
5. Build the solution and run the application.

## Usage
Once the application is running, you can access the home page through your web browser. The application provides user management functionalities, including creating and retrieving user information.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.