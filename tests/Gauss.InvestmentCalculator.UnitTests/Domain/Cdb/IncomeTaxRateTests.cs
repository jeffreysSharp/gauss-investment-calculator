using AwesomeAssertions;
using Gauss.InvestmentCalculator.Domain.Cdb;

namespace Gauss.InvestmentCalculator.UnitTests.Domain.Cdb;

public sealed class IncomeTaxRateTests
{
    [Theory(DisplayName = "Should return expected income tax rate by investment term")]
    [InlineData(2, 0.225)]
    [InlineData(6, 0.225)]
    [InlineData(7, 0.20)]
    [InlineData(12, 0.20)]
    [InlineData(13, 0.175)]
    [InlineData(24, 0.175)]
    [InlineData(25, 0.15)]
    [InlineData(120, 0.15)]
    public void GetByTermInMonths_ShouldReturnExpectedRate(
        int termInMonths,
        decimal expectedRate)
    {
        // Act
        var rate = IncomeTaxRate.GetByTermInMonths(termInMonths);

        // Assert
        rate.Should().Be(expectedRate);
    }
}
