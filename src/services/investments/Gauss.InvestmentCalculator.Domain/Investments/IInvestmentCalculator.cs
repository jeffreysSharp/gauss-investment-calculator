namespace Gauss.InvestmentCalculator.Domain.Investments;

public interface IInvestmentCalculator
{
    InvestmentSimulationResult Calculate(InvestmentSimulation simulation);
}
