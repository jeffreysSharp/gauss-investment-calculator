using Gauss.InvestmentCalculator.Domain.Cdb;
using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.UnitTests.Domain.Cdb;

public sealed class CdbInvestmentCalculatorTests
{
    [Fact]
    public void Calculate_ShouldReturnGrossAndNetAmounts_WhenSimulationIsValid()
    {
        var calculator = new CdbInvestmentCalculator();
        var simulation = InvestmentSimulation.Create(1000m, 2);

        var result = calculator.Calculate(simulation);

        Assert.Equal(1019.53m, result.GrossAmount);
        Assert.Equal(19.53m, result.ProfitAmount);
        Assert.Equal(0.225m, result.IncomeTaxRate);
        Assert.Equal(4.39m, result.IncomeTaxAmount);
        Assert.Equal(1015.14m, result.NetAmount);
    }
}
