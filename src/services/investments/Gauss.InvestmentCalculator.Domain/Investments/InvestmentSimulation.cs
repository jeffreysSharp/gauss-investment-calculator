namespace Gauss.InvestmentCalculator.Domain.Investments;

public sealed record InvestmentSimulation(
    InvestmentProductType ProductType,
    decimal InitialAmount,
    int TermInMonths)
{
    public static InvestmentSimulation Create(
        InvestmentProductType productType,
        decimal initialAmount,
        int termInMonths)
    {
        if (!Enum.IsDefined(productType))
        {
            throw new ArgumentOutOfRangeException(
                nameof(productType),
                "Investment product type is not supported.");
        }

        if (initialAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(initialAmount),
                "Initial investment amount must be greater than zero.");
        }

        if (termInMonths <= 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(termInMonths),
                "Investment term must be greater than one month.");
        }

        return new InvestmentSimulation(productType, initialAmount, termInMonths);
    }

    public static InvestmentSimulation CreateCdb(
        decimal initialAmount,
        int termInMonths)
    {
        return Create(
            InvestmentProductType.Cdb,
            initialAmount,
            termInMonths);
    }
}
