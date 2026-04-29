namespace Gauss.InvestmentCalculator.Api.Installers;

public sealed class CorsInstaller : IInstaller
{
    public const string PolicyName = "InvestmentCalculatorWeb";

    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, policy =>
            {
                policy
                    .WithOrigins(
                        "http://localhost:4200",
                        "https://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}