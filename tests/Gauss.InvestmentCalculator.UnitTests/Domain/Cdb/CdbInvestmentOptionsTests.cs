using AwesomeAssertions;
using Gauss.InvestmentCalculator.Domain.Cdb;
using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.UnitTests.Domain.Cdb;

public sealed class CdbInvestmentOptionsTests
{
    [Fact(DisplayName = "Should provide default CDB product configuration")]
    public void DefaultConfiguration_ShouldProvideDefaultCdbProductConfiguration()
    {
        // Act
        var configuration = CdbInvestmentOptions.DefaultConfiguration;

        // Assert
        configuration.ProductType.Should().Be(InvestmentProductType.Cdb);
        configuration.MonthlyIndexRate.Should().Be(0.009m);
        configuration.IndexPercentage.Should().Be(1.08m);
    }
}
