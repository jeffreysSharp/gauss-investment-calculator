using AwesomeAssertions;
using Gauss.InvestmentCalculator.Domain.Cdb;
using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.UnitTests.Domain.Cdb;

public sealed class CdbInvestmentCalculatorTests
{
    [Fact(DisplayName = "Should calculate gross amount for two months")]
    public void Calculate_ShouldCalculateGrossAmount_WhenTermIsTwoMonths()
    {
        // Arrange
        var calculator = new CdbInvestmentCalculator();
        var simulation = InvestmentSimulation.CreateCdb(1000m, 2);

        // Act
        var result = calculator.Calculate(simulation);

        // Assert
        result.InitialAmount.Should().Be(1000m);
        result.TermInMonths.Should().Be(2);
        result.GrossAmount.Should().Be(1019.53m);
    }

    [Fact(DisplayName = "Should calculate gross amount using monthly compound interest")]
    public void Calculate_ShouldCalculateGrossAmountUsingMonthlyCompoundInterest_WhenTermIsTwelveMonths()
    {
        // Arrange
        var calculator = new CdbInvestmentCalculator();
        var simulation = InvestmentSimulation.CreateCdb(1000m, 12);

        // Act
        var result = calculator.Calculate(simulation);

        // Assert
        result.GrossAmount.Should().Be(1123.08m);
    }

    [Fact(DisplayName = "Should calculate profit amount as gross amount minus initial amount")]
    public void Calculate_ShouldCalculateProfitAmount_WhenSimulationIsValid()
    {
        // Arrange
        var calculator = new CdbInvestmentCalculator();
        var simulation = InvestmentSimulation.CreateCdb(1000m, 2);

        // Act
        var result = calculator.Calculate(simulation);

        // Assert
        result.ProfitAmount.Should().Be(19.53m);
    }

    [Fact(DisplayName = "Should calculate income tax only over profit amount")]
    public void Calculate_ShouldCalculateIncomeTaxOnlyOverProfitAmount_WhenSimulationIsValid()
    {
        // Arrange
        var calculator = new CdbInvestmentCalculator();
        var simulation = InvestmentSimulation.CreateCdb(1000m, 2);

        // Act
        var result = calculator.Calculate(simulation);

        // Assert
        result.IncomeTaxRate.Should().Be(0.225m);
        result.IncomeTaxAmount.Should().Be(4.39m);
    }

    [Fact(DisplayName = "Should calculate net amount as gross amount minus income tax")]
    public void Calculate_ShouldCalculateNetAmount_WhenSimulationIsValid()
    {
        // Arrange
        var calculator = new CdbInvestmentCalculator();
        var simulation = InvestmentSimulation.CreateCdb(1000m, 2);

        // Act
        var result = calculator.Calculate(simulation);

        // Assert
        result.NetAmount.Should().Be(1015.14m);
    }

    [Theory(DisplayName = "Should calculate expected investment amounts")]
    [InlineData(1000, 2, 1019.53, 19.53, 0.225, 4.39, 1015.14)]
    [InlineData(1000, 6, 1059.76, 59.76, 0.225, 13.45, 1046.31)]
    [InlineData(1000, 7, 1070.06, 70.06, 0.20, 14.01, 1056.05)]
    [InlineData(1000, 12, 1123.08, 123.08, 0.20, 24.62, 1098.46)]
    [InlineData(1000, 13, 1134.00, 134.00, 0.175, 23.45, 1110.55)]
    [InlineData(1000, 24, 1261.31, 261.31, 0.175, 45.73, 1215.58)]
    [InlineData(1000, 25, 1273.57, 273.57, 0.15, 41.04, 1232.53)]
    public void Calculate_ShouldReturnExpectedAmounts_WhenSimulationIsValid(
    decimal initialAmount,
    int termInMonths,
    decimal expectedGrossAmount,
    decimal expectedProfitAmount,
    decimal expectedIncomeTaxRate,
    decimal expectedIncomeTaxAmount,
    decimal expectedNetAmount)
    {
        // Arrange
        var calculator = new CdbInvestmentCalculator();
        var simulation = InvestmentSimulation.CreateCdb(initialAmount, termInMonths);

        // Act
        var result = calculator.Calculate(simulation);

        // Assert
        result.GrossAmount.Should().Be(expectedGrossAmount);
        result.ProfitAmount.Should().Be(expectedProfitAmount);
        result.IncomeTaxRate.Should().Be(expectedIncomeTaxRate);
        result.IncomeTaxAmount.Should().Be(expectedIncomeTaxAmount);
        result.NetAmount.Should().Be(expectedNetAmount);
    }

    [Fact(DisplayName = "Should throw ArgumentNullException when simulation is null")]
    public void Calculate_ShouldThrowArgumentNullException_WhenSimulationIsNull()
    {
        // Arrange
        var calculator = new CdbInvestmentCalculator();

        // Act
        var act = () => calculator.Calculate(null!);

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .WithParameterName("simulation");
    }

    [Fact(DisplayName = "Should create CDB investment simulation when input is valid")]
    public void CreateCdb_ShouldCreateCdbInvestmentSimulation_WhenInputIsValid()
    {
        var simulation = InvestmentSimulation.CreateCdb(1000m, 12);

        simulation.ProductType.Should().Be(InvestmentProductType.Cdb);
        simulation.InitialAmount.Should().Be(1000m);
        simulation.TermInMonths.Should().Be(12);
    }
}
