using AwesomeAssertions;
using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.UnitTests.Domain.Investments;

public sealed class InvestmentProductConfigurationTests
{
    [Fact(DisplayName = "Should create investment product configuration when input is valid")]
    public void Create_ShouldCreateInvestmentProductConfiguration_WhenInputIsValid()
    {
        // Arrange
        const InvestmentProductType productType = InvestmentProductType.Cdb;
        const decimal monthlyIndexRate = 0.009m;
        const decimal indexPercentage = 1.08m;

        // Act
        var configuration = InvestmentProductConfiguration.Create(
            productType,
            monthlyIndexRate,
            indexPercentage);

        // Assert
        configuration.ProductType.Should().Be(productType);
        configuration.MonthlyIndexRate.Should().Be(monthlyIndexRate);
        configuration.IndexPercentage.Should().Be(indexPercentage);
    }

    [Fact(DisplayName = "Should throw ArgumentOutOfRangeException when product type is invalid")]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenProductTypeIsInvalid()
    {
        // Arrange
        const InvestmentProductType productType = (InvestmentProductType)999;
        const decimal monthlyIndexRate = 0.009m;
        const decimal indexPercentage = 1.08m;

        // Act
        var act = () => InvestmentProductConfiguration.Create(
            productType,
            monthlyIndexRate,
            indexPercentage);

        // Assert
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithParameterName("productType");
    }

    [Theory(DisplayName = "Should throw ArgumentOutOfRangeException when monthly index rate is invalid")]
    [InlineData(0)]
    [InlineData(-0.001)]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenMonthlyIndexRateIsInvalid(
        decimal monthlyIndexRate)
    {
        // Arrange
        const InvestmentProductType productType = InvestmentProductType.Cdb;
        const decimal indexPercentage = 1.08m;

        // Act
        var act = () => InvestmentProductConfiguration.Create(
            productType,
            monthlyIndexRate,
            indexPercentage);

        // Assert
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithParameterName("monthlyIndexRate");
    }

    [Theory(DisplayName = "Should throw ArgumentOutOfRangeException when index percentage is invalid")]
    [InlineData(0)]
    [InlineData(-1)]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenIndexPercentageIsInvalid(
        decimal indexPercentage)
    {
        // Arrange
        const InvestmentProductType productType = InvestmentProductType.Cdb;
        const decimal monthlyIndexRate = 0.009m;

        // Act
        var act = () => InvestmentProductConfiguration.Create(
            productType,
            monthlyIndexRate,
            indexPercentage);

        // Assert
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithParameterName("indexPercentage");
    }
}
