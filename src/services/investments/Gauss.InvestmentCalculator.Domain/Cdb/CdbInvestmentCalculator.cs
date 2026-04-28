using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.Domain.Cdb;

public sealed class CdbInvestmentCalculator : IInvestmentCalculator
{
    private const int MoneyScale = 2;
    private const MidpointRounding RoundingStrategy = MidpointRounding.AwayFromZero;

    public InvestmentSimulationResult Calculate(InvestmentSimulation simulation)
    {
        ArgumentNullException.ThrowIfNull(simulation);

        var grossAmount = simulation.InitialAmount;

        for (var month = 0; month < simulation.TermInMonths; month++)
        {
            grossAmount *= 1 + (CdbInvestmentOptions.MonthlyCdi * CdbInvestmentOptions.BankRate);
        }

        var roundedGrossAmount = RoundMoney(grossAmount);
        var profitAmount = RoundMoney(roundedGrossAmount - simulation.InitialAmount);
        var incomeTaxRate = IncomeTaxRate.GetByTermInMonths(simulation.TermInMonths);
        var incomeTaxAmount = RoundMoney(profitAmount * incomeTaxRate);
        var netAmount = RoundMoney(roundedGrossAmount - incomeTaxAmount);

        return new InvestmentSimulationResult(
            simulation.InitialAmount,
            simulation.TermInMonths,
            roundedGrossAmount,
            profitAmount,
            incomeTaxRate,
            incomeTaxAmount,
            netAmount);
    }

    private static decimal RoundMoney(decimal value)
    {
        return decimal.Round(value, MoneyScale, RoundingStrategy);
    }
}
