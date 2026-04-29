using AwesomeAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Json;

namespace Gauss.InvestmentCalculator.IntegrationTests.Api.Investments;

public sealed class CdbSimulationEndpointTests(
    InvestmentCalculatorApiFactory factory)
    : IClassFixture<InvestmentCalculatorApiFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact(DisplayName = "Should return OK with CDB simulation result when request is valid")]
    public async Task Post_ShouldReturnOkWithSimulationResult_WhenRequestIsValid()
    {
        // Arrange
        var request = new
        {
            InitialAmount = 1000m,
            TermInMonths = 12,
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/investments/cdb/simulations",
            request);

        var result = await response.Content.ReadFromJsonAsync<CdbSimulationResponse>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        result.Should().NotBeNull();
        result!.InitialAmount.Should().Be(1000m);
        result.TermInMonths.Should().Be(12);
        result.GrossAmount.Should().Be(1123.08m);
        result.ProfitAmount.Should().Be(123.08m);
        result.IncomeTaxRate.Should().Be(0.20m);
        result.IncomeTaxAmount.Should().Be(24.62m);
        result.NetAmount.Should().Be(1098.46m);
    }

    [Fact(DisplayName = "Should return BadRequest when initial amount is zero")]
    public async Task Post_ShouldReturnBadRequest_WhenInitialAmountIsZero()
    {
        // Arrange
        var request = new
        {
            InitialAmount = 0m,
            TermInMonths = 12,
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/investments/cdb/simulations",
            request);

        var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        problemDetails.Should().NotBeNull();
        problemDetails!.Errors.Should().ContainKey("InitialAmount");
    }

    [Fact(DisplayName = "Should return BadRequest when term in months is one")]
    public async Task Post_ShouldReturnBadRequest_WhenTermInMonthsIsOne()
    {
        // Arrange
        var request = new
        {
            InitialAmount = 1000m,
            TermInMonths = 1,
        };

        // Act
        var response = await _client.PostAsJsonAsync(
            "/api/investments/cdb/simulations",
            request);

        var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        problemDetails.Should().NotBeNull();
        problemDetails!.Errors.Should().ContainKey("TermInMonths");
    }

    [Fact(DisplayName = "Should return Healthy when health endpoint is called")]
    public async Task GetHealth_ShouldReturnHealthy_WhenApiIsRunning()
    {
        // Act
        var response = await _client.GetAsync("/health");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().Be("Healthy");
    }
}
