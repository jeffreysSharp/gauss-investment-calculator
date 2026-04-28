namespace Gauss.InvestmentCalculator.Domain.Cdb;

public static class IncomeTaxRate
{
    public const decimal UpToSixMonths = 0.225m;
    public const decimal UpToTwelveMonths = 0.20m;
    public const decimal UpToTwentyFourMonths = 0.175m;
    public const decimal AboveTwentyFourMonths = 0.15m;

    public static decimal GetByTermInMonths(int termInMonths)
    {
        if (termInMonths <= 6)
        {
            return UpToSixMonths;
        }

        if (termInMonths <= 12)
        {
            return UpToTwelveMonths;
        }

        if (termInMonths <= 24)
        {
            return UpToTwentyFourMonths;
        }

        return AboveTwentyFourMonths;
    }
}
