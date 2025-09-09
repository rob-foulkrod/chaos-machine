# ChaosMachine

A .NET 8.0 ASP.NET Core web application with comprehensive test coverage.

## Project Structure

```
ChaosMachine/
├── ChaosMachine/                    # Main web application
│   ├── Controllers/                 # MVC Controllers
│   │   └── HomeController.cs       # Home page controller
│   ├── Models/                      # Data models
│   │   └── ErrorViewModel.cs       # Error page view model
│   ├── Views/                       # Razor views
│   ├── wwwroot/                     # Static files
│   ├── Program.cs                   # Application entry point
│   └── ChaosMachine.csproj         # Main project file
├── ChaosMachine.Tests/              # Test project
│   ├── HomeControllerTests.cs       # Unit tests for HomeController
│   ├── ErrorViewModelTests.cs      # Unit tests for ErrorViewModel
│   ├── IntegrationTests.cs         # Integration tests
│   └── ChaosMachine.Tests.csproj   # Test project file
├── ChaosMachine.sln                 # Solution file
└── run-tests-with-coverage.sh      # Script to run tests with coverage
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Any compatible IDE (Visual Studio, Visual Studio Code, JetBrains Rider, etc.)

### Building the Project

```bash
# Build the entire solution
dotnet build

# Build specific project
dotnet build ChaosMachine/ChaosMachine.csproj
```

### Running the Application

```bash
# Run the web application
dotnet run --project ChaosMachine

# Or from the ChaosMachine directory
cd ChaosMachine
dotnet run
```

The application will be available at `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP).

## Test Execution

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity normal

# Run tests from specific project
dotnet test ChaosMachine.Tests/ChaosMachine.Tests.csproj
```

### Code Coverage

The project includes comprehensive code coverage reporting using Coverlet.

#### Quick Coverage Run
```bash
# Run tests with basic coverage collection
dotnet test --collect:"XPlat Code Coverage"
```

#### Detailed Coverage Report
```bash
# Use the provided script for HTML coverage reports
./run-tests-with-coverage.sh
```

This will:
1. Run all tests with coverage collection
2. Generate an HTML coverage report
3. Display coverage summary in the console
4. Save detailed reports to `./TestResults/CoverageReport/`

#### Coverage Results
Current test coverage includes:
- **Line Coverage**: 91.3%
- **Branch Coverage**: 96.4%
- **Method Coverage**: 100%

### Test Structure

The test suite includes:

1. **Unit Tests**
   - `HomeControllerTests.cs`: Tests for all HomeController actions
   - `ErrorViewModelTests.cs`: Tests for ErrorViewModel properties and behavior

2. **Integration Tests**
   - `IntegrationTests.cs`: End-to-end HTTP tests for all endpoints

### Test Dependencies

The test project uses:
- **xUnit**: Testing framework
- **Moq**: Mocking framework for unit tests
- **Microsoft.AspNetCore.Mvc.Testing**: Integration testing framework
- **Coverlet**: Code coverage collection
- **ReportGenerator**: HTML coverage report generation

## Development Workflow

1. **Make Changes**: Modify code in the `ChaosMachine` project
2. **Run Tests**: Execute `dotnet test` to ensure all tests pass
3. **Check Coverage**: Run `./run-tests-with-coverage.sh` to verify coverage
4. **Build**: Execute `dotnet build` to ensure the project compiles
5. **Test Locally**: Run `dotnet run --project ChaosMachine` to test manually

## Contributing

When contributing to this project:
1. Ensure all existing tests pass
2. Add tests for new functionality
3. Maintain or improve code coverage
4. Follow the existing code style and patterns