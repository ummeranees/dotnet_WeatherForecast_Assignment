Weather Service APIs:

Table of Contents
1)Overview
2)Architecture
3)API Endpoints
4)Implementation Details
5)Running the APIs
6)Unit Testing

Overview:
This project contains two Weather Service APIs:

Weather  API (Service 1): Provides random weather data for a specific location and date.
Weather Forecast Service API (Service 2): Provides weather forecasts for the next 365 days for a specific location. This API internally consumes Service 1.

Architecture:
Both APIs are built using .NET Core and follow the n-tier architecture, which separates the concerns into different layers: Presentation, Service, and Repository. The APIs also include error handling.

Weather Service API (Service 1)
Endpoint: /weather
HTTP Method: GET
Parameters: location, date
Response: JSON containing weather data for the given location and date.
https://localhost:44367/Weather?location=Bangalore&date=2024-06-08


Weather Forecast Service API (Service 2)
Endpoint: /weatherforecast
HTTP Method: GET
Parameters: location
Response: JSON containing weather data for the next 365 days for the given location.
https://localhost:44316/WeatherForecast?location=Bangalore


Implementation Details:
Weather Service API (Service 1)
Controller: WeatherForecastController handles incoming requests and returns random weather data.
Service Layer: Contains the business logic to generate random weather data.
Repository Layer: Interacts with the data source (in-memory or database).
Implemented GZIP compression - responses for API2 has decreased by nearly ~1 sec .Added comparison pictures.


Weather Forecast Service API (Service 2)
Controller: WeatherForecastController handles incoming requests for weather forecasts.
Service Layer: Contains the business logic to fetch data from Service 1 for the next 365 days.
Repository Layer: Makes HTTP calls to Service 1 to retrieve weather data.



Error Handling:
Both APIs include try-catch blocks to handle exceptions and return appropriate HTTP status codes.

Dependency Injection:
Both services and repositories are registered using Scoped DI to ensure a new instance for each request.

Running the APIs:
Prerequisites
.NET Core SDK
Visual Studio or VS Code
Postman (for testing the endpoints)

Running Service 1
Navigate to the Service 1 project directory and run the project.

Running Service 2
Navigate to the Service 2 project directory.
Ensure Service 1 is running, as Service 2 depends on it.
Update the API1 url in appsettings.json (port might be different)

Swagger is also Enabled


Unit Testing:
Tools Used
xUnit for unit testing
Moq for mocking dependencies
Coverlet for code coverage

Running Unit Tests:
Can use VS to run unit tests.

Code Coverage:
Prerequisites:
report generator needs to be installed in the system .
For this Run the command in CMD (admin mode) - 'dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.3.8' replace with whaever stable version or the package versio in unit tests.

Head Over to the Solution folder in file Explorer , open the test project and run the batch(.bat) file , once done it opens report in default browser.

If still report isnt generating , On the Solution folder level , right click=>properties=>uncheck readonly and apply => then try again.
