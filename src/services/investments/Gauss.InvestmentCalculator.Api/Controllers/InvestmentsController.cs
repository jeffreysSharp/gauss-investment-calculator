using Gauss.InvestmentCalculator.Api.Contracts.Investments;
using Gauss.InvestmentCalculator.Domain.Investments;
using Microsoft.AspNetCore.Mvc;

namespace Gauss.InvestmentCalculator.Api.Controllers;

[ApiController]
[Route("api/investments")]
public sealed class InvestmentsController(IInvestmentCalculator investmentCalculator) : ControllerBase
{
    [HttpPost("cdb/simulations")]
    [ProducesResponseType<CalculateCdbInvestmentResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public ActionResult<CalculateCdbInvestmentResponse> CalculateCdbInvestment(
        [FromBody] CalculateCdbInvestmentRequest request)
    {
        var simulation = InvestmentSimulation.Create(
            request.InitialAmount,
            request.TermInMonths);

        var result = investmentCalculator.Calculate(simulation);

        var response = new CalculateCdbInvestmentResponse(
            result.InitialAmount,
            result.TermInMonths,
            result.GrossAmount,
            result.ProfitAmount,
            result.IncomeTaxRate,
            result.IncomeTaxAmount,
            result.NetAmount);

        return Ok(response);
    }
}
