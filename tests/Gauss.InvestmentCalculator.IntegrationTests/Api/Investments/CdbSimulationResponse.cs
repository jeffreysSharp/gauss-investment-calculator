namespace Gauss.InvestmentCalculator.IntegrationTests.Api.Investments;

public sealed record CdbSimulationResponse(
    decimal InitialAmount,
    int TermInMonths,
    decimal GrossAmount,
    decimal ProfitAmount,
    decimal IncomeTaxRate,
    decimal IncomeTaxAmount,
    decimal NetAmount);
