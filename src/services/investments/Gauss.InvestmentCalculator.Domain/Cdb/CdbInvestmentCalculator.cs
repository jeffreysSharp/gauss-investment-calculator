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

        return new InvestmentSimulationResult(
            simulation.InitialAmount,
            simulation.TermInMonths,
            decimal.Round(grossAmount, MoneyScale, RoundingStrategy));
    }
}
