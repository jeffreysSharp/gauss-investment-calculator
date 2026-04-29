namespace Gauss.InvestmentCalculator.Api.Contracts.Investments;

public sealed record CalculateCdbInvestmentResponse(
    decimal InitialAmount,
    int TermInMonths,
    decimal GrossAmount,
    decimal ProfitAmount,
    decimal IncomeTaxRate,
    decimal IncomeTaxAmount,
    decimal NetAmount);
