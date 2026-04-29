using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gauss.InvestmentCalculator.Api.Contracts.Investments;

public sealed record CalculateCdbInvestmentRequest
{
    [JsonRequired]
    [Range(0.01, double.MaxValue, ErrorMessage = "Initial amount must be greater than zero.")]
    public decimal InitialAmount { get; init; }

    [JsonRequired]
    [Range(2, int.MaxValue, ErrorMessage = "Term in months must be greater than one.")]
    public int TermInMonths { get; init; }
}
