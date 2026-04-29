# GAUSS Investment Calculator

**GAUSS Investment Calculator** is an investment simulation platform built with **.NET 10**, **C# 14**, **Angular 19**, **TypeScript** and **Tailwind CSS**.

The current version provides a complete CDB fixed-income simulation experience, including:

- Gross amount calculation
- Profit calculation
- Income tax calculation
- Net amount calculation
- REST API
- Angular web interface
- Unit tests
- Integration tests
- GitHub Actions CI
- Azure public demo environment

The platform started with CDB simulation, but the domain model is being prepared to support additional investment products in future iterations.

---

## Public Demo

The application is published on Azure and can be accessed through the following links.

### Web Application

```text
https://ashy-river-0c0baee0f.7.azurestaticapps.net/
```

### Backend API

```text
https://app-gauss-investment-calculator-api-dev.azurewebsites.net/
```

### API Documentation

```text
https://app-gauss-investment-calculator-api-dev.azurewebsites.net/scalar
```

### Health Check

```text
https://app-gauss-investment-calculator-api-dev.azurewebsites.net/health
```

The public demo environment uses:

- **Azure Static Web Apps** for the Angular frontend
- **Azure App Service** for the .NET API
- HTTPS communication between frontend and backend
- CORS configured for the published frontend URL

---

## Technologies

### Backend

- .NET 10
- C# 14
- ASP.NET Core Web API
- RESTful API
- Scalar API Reference
- Health Checks
- xUnit
- AwesomeAssertions
- Microsoft.AspNetCore.Mvc.Testing
- Coverlet

### Frontend

- Angular 19
- TypeScript
- Tailwind CSS
- Reactive Forms
- Standalone Components
- Environment-based API configuration
- HTML and CSS separated from TypeScript

### DevOps and Cloud

- GitHub
- GitHub Actions
- Azure Static Web Apps
- Azure App Service
- Azure DevOps Boards

---

## Solution Structure

```text
src/
  services/
    investments/
      Gauss.InvestmentCalculator.Api/
      Gauss.InvestmentCalculator.Domain/

  web/
    src/
    angular.json
    package.json
    package-lock.json

tests/
  Gauss.InvestmentCalculator.UnitTests/
  Gauss.InvestmentCalculator.IntegrationTests/

docs/
  architecture/
    investment-product-catalog.md

.github/
  workflows/
    ci.yml
    azure-static-web-apps-ashy-river-0c0baee0f.yml
```

---

## Architecture

The solution follows a pragmatic and simplified architecture focused on clarity, testability and incremental evolution.

The current backend is organized into two main projects:

```text
Gauss.InvestmentCalculator.Api
Gauss.InvestmentCalculator.Domain
```

### Domain

The Domain project contains the core business rules and investment concepts.

Responsibilities:

- Validate investment simulation input
- Represent investment product types
- Represent investment product configuration
- Calculate CDB gross amount
- Calculate profit amount
- Apply income tax rules
- Calculate net amount
- Prepare the model for future investment products

Current domain concepts include:

```text
InvestmentSimulation
InvestmentSimulationResult
InvestmentProductType
InvestmentProductConfiguration
InvestmentProduct
InvestmentProductStatus
CdbInvestmentCalculator
IncomeTaxRate
```

### API

The API project exposes the investment simulation through REST endpoints.

Responsibilities:

- Receive HTTP requests
- Validate request contracts
- Execute investment simulation
- Return response contracts
- Expose Scalar API documentation
- Expose health check endpoint
- Configure dependency injection through installers
- Configure CORS for local and cloud environments

### Web

The Angular application is responsible for user interaction.

Responsibilities:

- Provide the investment calculator UI
- Validate user input
- Call the backend API
- Display gross and net simulation results
- Use development and production API configuration by environment

---

## Current Features

- CDB investment simulation
- Monthly compound interest calculation
- Fixed CDI rate configuration
- Fixed bank rate over CDI configuration
- Brazilian income tax rules by investment term
- Gross amount calculation
- Profit amount calculation
- Income tax rate selection
- Income tax amount calculation
- Net amount calculation
- REST API endpoint
- API documentation with Scalar
- API health check endpoint
- Angular web interface in pt-BR
- Environment-based frontend API URL
- Unit tests for business rules
- Integration tests for API endpoints
- GitHub Actions CI workflow
- Public Azure demo environment
- Product Catalog boundary documentation
- Initial domain preparation for multiple investment products

---

## CDB Calculation Rule

The CDB calculation uses the following monthly formula:

```text
VF = VI x [1 + (CDI x TB)]
```

Where:

```text
VF = Final amount
VI = Initial amount
CDI = Monthly CDI rate
TB = Bank rate over CDI
```

For the current CDB implementation, the default product configuration is:

```text
CDI = 0.9% per month
TB = 108%
```

Converted to decimal values:

```text
CDI = 0.009
TB = 1.08
```

Monthly effective rate:

```text
0.009 x 1.08 = 0.00972
```

The formula is applied month by month, using the result of each month as the base amount for the next month.

---

## Income Tax Rules

Income tax is applied only over the investment profit, not over the full gross amount.

| Investment Term | Income Tax Rate |
|---:|---:|
| Up to 6 months | 22.5% |
| Up to 12 months | 20% |
| Up to 24 months | 17.5% |
| Above 24 months | 15% |

The net amount is calculated as:

```text
Net Amount = Gross Amount - Income Tax Amount
```

---

## API Endpoints

### Calculate CDB Investment

```http
POST /api/investments/cdb/simulations
```

#### Request

```json
{
  "initialAmount": 1000,
  "termInMonths": 12
}
```

#### Response

```json
{
  "initialAmount": 1000,
  "termInMonths": 12,
  "grossAmount": 1123.08,
  "profitAmount": 123.08,
  "incomeTaxRate": 0.2,
  "incomeTaxAmount": 24.62,
  "netAmount": 1098.46
}
```

### Health Check

```http
GET /health
```

#### Response

```text
Healthy
```

---

## Example Simulation

For an initial amount of:

```text
R$ 1,000.00
```

And an investment term of:

```text
12 months
```

The expected result is:

```text
Gross Amount: R$ 1,123.08
Profit Amount: R$ 123.08
Income Tax Rate: 20%
Income Tax Amount: R$ 24.62
Net Amount: R$ 1,098.46
```

---

## Prerequisites

Make sure you have the following tools installed:

- .NET SDK 10
- Node.js LTS
- npm
- Git

Recommended Node.js versions:

```text
Node.js 20 LTS or Node.js 22 LTS
```

---

## Running the Backend API

From the repository root:

```bash
dotnet restore
dotnet build
dotnet run --project src/services/investments/Gauss.InvestmentCalculator.Api/Gauss.InvestmentCalculator.Api.csproj
```

The API will be available at:

```text
https://localhost:7026
```

Scalar API documentation will be available at:

```text
https://localhost:7026/scalar
```

Health check will be available at:

```text
https://localhost:7026/health
```

---

## Running the Frontend

From the repository root:

```bash
cd src/web
npm install
npm start
```

The Angular application will be available at:

```text
http://localhost:4200
```

In development mode, the frontend points to:

```text
https://localhost:7026
```

In production build, the frontend points to:

```text
https://app-gauss-investment-calculator-api-dev.azurewebsites.net
```

---

## Running Tests

From the repository root:

```bash
dotnet test --configuration Release
```

This command runs:

- Unit tests
- Integration tests

---

## Running Tests with Code Coverage

From the repository root:

```bash
dotnet test --configuration Release --collect:"XPlat Code Coverage"
```

If you want to generate an HTML coverage report, install ReportGenerator:

```bash
dotnet tool install --global dotnet-reportgenerator-globaltool
```

Then run:

```bash
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coverage-report" -reporttypes:Html
```

Open the generated report:

```text
coverage-report/index.html
```

---

## Building the Frontend

From the repository root:

```bash
cd src/web
npm ci
npm run build
```

---

## Full Local Validation

From the repository root, validate the backend:

```bash
dotnet clean
dotnet restore
dotnet build --configuration Release
dotnet test --configuration Release
```

Then validate the frontend:

```bash
cd src/web
npm ci
npm run build
```

---

## Cloud Validation

The published environment can be validated using the public web application:

```text
https://ashy-river-0c0baee0f.7.azurestaticapps.net/
```

Example simulation:

```text
Initial amount: 1000
Term in months: 12
```

Expected result:

```text
Gross Amount: R$ 1,123.08
Net Amount: R$ 1,098.46
Profit Amount: R$ 123.08
Income Tax Amount: R$ 24.62
Income Tax Rate: 20%
```

The published API can also be validated through:

```text
https://app-gauss-investment-calculator-api-dev.azurewebsites.net/scalar
```

---

## Continuous Integration

The project uses GitHub Actions for automated validation.

The CI workflow runs on pushes and pull requests and validates:

- .NET restore
- .NET build
- .NET tests
- Node.js setup
- npm dependency installation through `npm ci`
- Angular production build

Workflow file:

```text
.github/workflows/ci.yml
```

The Azure Static Web Apps deployment workflow is generated by Azure and publishes the frontend when changes are merged into `main`.

Workflow file:

```text
.github/workflows/azure-static-web-apps-ashy-river-0c0baee0f.yml
```

---

## Design Decisions

### Pragmatic Architecture

The solution keeps the architecture simple and honest. The unused Application layer was removed to avoid unnecessary abstraction and keep the implementation aligned with the current domain needs.

### Domain-Centered Business Rules

Business rules are isolated in the Domain project, keeping calculation logic independent from API and UI concerns.

### Multi-Product Foundation

Although the first supported product is CDB, the domain model includes product type and product configuration concepts to support future investment products.

### Product Catalog Boundary

The Product Catalog boundary is documented in:

```text
docs/architecture/investment-product-catalog.md
```

This boundary prepares the future evolution toward product registration and configuration without prematurely introducing persistence or CRUD APIs.

### Request and Response Contracts

The API uses explicit `Request` and `Response` contract naming instead of generic DTO naming, improving readability and intent.

### Installers Pattern

Dependency injection is organized using the `Installers` pattern, keeping `Program.cs` clean and focused on application startup.

### Scalar API Reference

Scalar is used to provide a modern and clean API documentation interface.

### Environment-Based Frontend Configuration

The Angular application uses environment configuration to separate local development API URLs from the production Azure API URL.

### Tailwind CSS

Tailwind CSS is used in the Angular application to create a clean, responsive and maintainable UI without adding heavy UI component dependencies.

---

## Future Improvements

Possible future evolutions:

- Support for additional fixed-income products
- Product Catalog CRUD
- Product configuration persistence
- Tenant-specific product configuration
- Simulation history
- Export simulation results
- Authentication and authorization
- Docker support
- Frontend unit tests
- End-to-end tests
- Observability and structured logs
- API versioning
- Database persistence
- Admin UI for investment products

---

## Author

**Jeferson Almeida**

```text
Phone: +55 11 99754-1210
Email: jeffreys.sharp@outlook.com
LinkedIn: https://www.linkedin.com/in/jeffreys-sharp
```

---

## License

This project is available for study, evaluation and portfolio purposes.