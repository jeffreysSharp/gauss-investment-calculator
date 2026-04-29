# Investment Product Catalog Boundary

## Purpose

The Investment Product Catalog defines the available financial products that can be configured, offered and used by the investment simulation engine.

The current platform started with a CDB simulation, but the architecture must support future financial products without coupling the simulation engine to a single product type.

This document defines the initial boundary between:

- Product configuration
- Investment simulation
- Future product administration
- Future proposal and contracting flows

---

## Context

The current implementation supports CDB simulation using:

- Product type: CDB
- Monthly CDI rate
- Bank percentage over CDI
- Income tax rules
- Gross amount calculation
- Net amount calculation

These values are currently represented as product configuration in the domain layer, allowing the platform to evolve toward configurable products in future iterations.

---

## Product Catalog Responsibilities

The Product Catalog will be responsible for managing financial product definitions and their simulation-related configuration.

Initial responsibilities:

- Register investment products
- Identify the product type
- Define product display name
- Define whether the product is active
- Define product simulation configuration
- Define index rate configuration
- Define bank percentage over index
- Define minimum and maximum investment term
- Define minimum and maximum investment amount
- Provide product configuration to the simulation engine

Future responsibilities may include:

- Product availability rules
- Product eligibility rules
- Product versioning
- Product approval workflow
- Product audit history
- Tenant-specific product configuration
- Institution-specific product catalog

---

## Out of Scope

The Product Catalog is not responsible for:

- Calculating investment returns
- Calculating income tax
- Creating proposals
- Managing customers
- Managing contracts
- Executing payments or settlement
- Performing credit analysis
- Managing authentication or authorization
- Persisting simulation history

These responsibilities belong to other platform boundaries.

---

## Relationship with Investment Simulation

The Investment Simulation boundary is responsible for calculating investment results.

The Product Catalog provides product configuration.

The Simulation Engine consumes the product configuration and applies product-specific calculation rules.

Conceptual flow:

```text
Product Catalog
      |
      | provides product configuration
      v
Investment Simulation Engine
      |
      | calculates gross amount, taxes and net amount
      v
Simulation Result
```

For the current CDB implementation:

```text
CDB Product Configuration
      |
      | Monthly CDI: 0.9%
      | Bank Rate: 108%
      v
CDB Investment Calculator
      |
      v
Gross Amount / Profit / Income Tax / Net Amount
```

---

## Initial Conceptual Model

A future product catalog model may include:

```text
InvestmentProduct
  Id
  ProductType
  Name
  Description
  Status
  MinimumAmount
  MaximumAmount
  MinimumTermInMonths
  MaximumTermInMonths
  Configuration
```

```text
InvestmentProductConfiguration
  ProductType
  MonthlyIndexRate
  IndexPercentage
```

```text
InvestmentProductStatus
  Active
  Inactive
  Draft
```

The current domain already contains the initial `InvestmentProductConfiguration` concept used by the CDB calculator.

---

## Product Types

The first supported product type is:

```text
CDB
```

Future product types may include:

```text
LCI
LCA
Tesouro Direto
Fundos
Previdência
Debêntures
CRI
CRA
```

Each product may require different calculation rules, taxation rules and eligibility rules.

---

## Design Principles

The Product Catalog must follow these principles:

- Product configuration must be explicit.
- Product-specific rules must not leak into generic simulation contracts.
- The simulation engine must not depend on persistence details.
- New products should be added without breaking existing CDB behavior.
- Product configuration should be testable without external dependencies.
- Public API contracts must remain stable unless a versioned change is introduced.

---

## Future API Direction

A future Product Catalog API may expose endpoints such as:

```http
GET /api/investment-products
GET /api/investment-products/{id}
POST /api/investment-products
PUT /api/investment-products/{id}
PATCH /api/investment-products/{id}/activate
PATCH /api/investment-products/{id}/deactivate
```

The current API remains focused on CDB simulation:

```http
POST /api/investments/cdb/simulations
```

This endpoint should remain stable while the platform evolves.

---

## Future Service Boundary

As the platform grows, the catalog may become its own service boundary:

```text
Services/
  Investments/
    ProductCatalog/
    Simulation/
    Proposal/
    Contract/
```

For now, the catalog remains a documented boundary and should only be implemented when persistence and CRUD requirements are clearly defined.

---

## Next Steps

Recommended next steps:

1. Define the `InvestmentProduct` domain model.
2. Define supported product statuses.
3. Define validation rules for amount and term limits.
4. Keep CDB configuration as the first default product.
5. Add unit tests for product model validation.
6. Postpone database persistence until the CRUD boundary is approved.
7. Preserve current public simulation behavior.

---

## Current Decision

The platform will not implement Product Catalog persistence yet.

The current decision is to document the boundary, preserve the existing public CDB simulation, and evolve the domain model incrementally before introducing database, CRUD or administrative UI concerns.