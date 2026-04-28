namespace Gauss.InvestmentCalculator.Domain.Investments;

public sealed record InvestmentSimulation(decimal InitialAmount, int TermInMonths)
{
    public static InvestmentSimulation Create(decimal initialAmount, int termInMonths)
    {
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

        return new InvestmentSimulation(initialAmount, termInMonths);
    }
}
