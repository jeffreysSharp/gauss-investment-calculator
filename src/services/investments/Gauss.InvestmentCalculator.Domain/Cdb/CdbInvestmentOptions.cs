using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.Domain.Cdb;

public static class CdbInvestmentOptions
{
    public const decimal MonthlyCdi = 0.009m;
    public const decimal BankRate = 1.08m;

    public static InvestmentProductConfiguration DefaultConfiguration =>
        InvestmentProductConfiguration.Create(
            InvestmentProductType.Cdb,
            MonthlyCdi,
            BankRate);
}
