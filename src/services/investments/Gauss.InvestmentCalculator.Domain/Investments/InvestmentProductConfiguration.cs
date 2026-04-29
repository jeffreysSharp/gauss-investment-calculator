namespace Gauss.InvestmentCalculator.Domain.Investments;

public sealed record InvestmentProductConfiguration(
    InvestmentProductType ProductType,
    decimal MonthlyIndexRate,
    decimal IndexPercentage)
{
    public static InvestmentProductConfiguration Create(
        InvestmentProductType productType,
        decimal monthlyIndexRate,
        decimal indexPercentage)
    {
        if (!Enum.IsDefined(productType))
        {
            throw new ArgumentOutOfRangeException(
                nameof(productType),
                "Investment product type is not supported.");
        }

        if (monthlyIndexRate <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(monthlyIndexRate),
                "Monthly index rate must be greater than zero.");
        }

        if (indexPercentage <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(indexPercentage),
                "Index percentage must be greater than zero.");
        }

        return new InvestmentProductConfiguration(
            productType,
            monthlyIndexRate,
            indexPercentage);
    }
}