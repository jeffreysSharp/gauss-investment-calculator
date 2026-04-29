# GAUSS Investment Calculator

Investment calculator platform built with **.NET 10**, **Angular 19**, **TypeScript** and **Tailwind CSS**.

The first version provides a CDB fixed-income investment simulation, calculating gross return, net return, profit amount, income tax amount and applicable income tax rate based on the investment term.

---

## Overview

This project was designed with a clean and extensible architecture, keeping business rules isolated from API and UI concerns.

The current implementation supports:

- CDB investment simulation
- Monthly compound interest calculation
- Fixed CDI rate
- Fixed bank rate over CDI
- Brazilian income tax rules by investment term
- Gross amount calculation
- Net amount calculation
- REST API
- Angular web interface
- Unit tests for business logic
- API documentation with Scalar

---

## Technologies

### Backend

- .NET 10
- C# 14
- ASP.NET Core Web API
- Clean Architecture
- RESTful API
- Scalar API Reference
- xUnit
- AwesomeAssertions
- Coverlet

### Frontend

- Angular 19
- TypeScript
- Tailwind CSS
- Reactive Forms
- Standalone Components
- HTML and CSS separated from TypeScript

---

## Solution Structure

```text
src/
  services/
    investments/
      Gauss.InvestmentCalculator.Api/
      Gauss.InvestmentCalculator.Application/
      Gauss.InvestmentCalculator.Domain/

  web/
    src/
    angular.json
    package.json
    tailwind.config.js

tests/
  Gauss.InvestmentCalculator.UnitTests/
```

---

## Architecture

The solution follows a simplified Clean Architecture approach.

### Domain

Contains the core business rules and investment calculation logic.

```text
Gauss.InvestmentCalculator.Domain
```

Responsibilities:

- Validate investment simulation input
- Calculate CDB gross amount
- Calculate profit amount
- Apply income tax rules
- Calculate net amount

### Application

Reserved for application orchestration and use cases.

```text
Gauss.InvestmentCalculator.Application
```

### API

Exposes the investment simulation through a REST endpoint.

```text
Gauss.InvestmentCalculator.Api
```

### Web

Angular application responsible for user interaction.

```text
src/web
```

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

For this implementation, the fixed values are:

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

## API Endpoint

### Calculate CDB Investment

```http
POST /api/investments/cdb/simulations
```

### Request

```json
{
  "initialAmount": 1000,
  "termInMonths": 12
}
```

### Response

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

---

## Running Tests

From the repository root:

```bash
dotnet test --configuration Release
```

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
npm install
npm run build
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

## Design Decisions

### Clean Architecture

Business rules are isolated in the Domain layer, keeping the API and UI layers dependent on stable abstractions and simple contracts.

### Request and Response Contracts

The API uses explicit `Request` and `Response` contract naming instead of generic DTO naming, improving readability and intent.

### Installers Pattern

Dependency injection is organized using the `Installers` pattern, keeping `Program.cs` clean and focused on application startup.

### Scalar API Reference

Scalar is used to provide a modern and clean API documentation interface during development.

### Tailwind CSS

Tailwind CSS is used in the Angular application to create a clean, responsive and maintainable UI without adding heavy UI component dependencies.

---

## Current Features

- CDB investment calculation
- Gross amount calculation
- Profit amount calculation
- Income tax rate selection
- Income tax amount calculation
- Net amount calculation
- REST API endpoint
- Angular web interface in pt-BR
- API documentation with Scalar
- Unit tests for business rules

---

## Future Improvements

Possible future evolutions:

- Support for additional fixed-income products
- Configurable CDI and bank rate values
- Simulation history
- Export simulation results
- Authentication
- Docker support
- CI/CD pipeline
- End-to-end tests
- Frontend unit tests
- API integration tests

---

## License

This project is available for study, evaluation and portfolio purposes.