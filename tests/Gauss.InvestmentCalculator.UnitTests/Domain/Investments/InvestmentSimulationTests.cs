using AwesomeAssertions;
using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.UnitTests.Domain.Investments;

public sealed class InvestmentSimulationTests
{
    [Fact(DisplayName = "Should create investment simulation when input is valid")]
    public void Create_ShouldCreateInvestmentSimulation_WhenInputIsValid()
    {
        // Arrange
        const decimal initialAmount = 1000m;
        const int termInMonths = 12;

        // Act
        var simulation = InvestmentSimulation.CreateCdb(initialAmount, termInMonths);

        // Assert
        simulation.InitialAmount.Should().Be(initialAmount);
        simulation.TermInMonths.Should().Be(termInMonths);
    }

    [Theory(DisplayName = "Should throw ArgumentOutOfRangeException when initial amount is invalid")]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-1000)]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenInitialAmountIsInvalid(
        decimal initialAmount)
    {
        // Arrange
        const int termInMonths = 12;

        // Act
        var act = () => InvestmentSimulation.CreateCdb(initialAmount, termInMonths);

        // Assert
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithParameterName("initialAmount");
    }

    [Theory(DisplayName = "Should throw ArgumentOutOfRangeException when term is invalid")]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenTermIsInvalid(
        int termInMonths)
    {
        // Arrange
        const decimal initialAmount = 1000m;

        // Act
        var act = () => InvestmentSimulation.CreateCdb(initialAmount, termInMonths);

        // Assert
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithParameterName("termInMonths");
    }
}
