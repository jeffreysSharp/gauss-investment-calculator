namespace Gauss.InvestmentCalculator.Domain.Investments;

public sealed record InvestmentSimulationResult(
    decimal InitialAmount,
    int TermInMonths,
    decimal GrossAmount);
