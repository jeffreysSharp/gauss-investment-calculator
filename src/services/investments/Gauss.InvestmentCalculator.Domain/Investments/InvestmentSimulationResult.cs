namespace Gauss.InvestmentCalculator.Domain.Investments;

public sealed record InvestmentSimulationResult(
    InvestmentProductType ProductType,
    decimal InitialAmount,
    int TermInMonths,
    decimal GrossAmount,
    decimal ProfitAmount,
    decimal IncomeTaxRate,
    decimal IncomeTaxAmount,
    decimal NetAmount);
