using Gauss.InvestmentCalculator.Domain.Cdb;
using Gauss.InvestmentCalculator.Domain.Investments;

namespace Gauss.InvestmentCalculator.Api.Installers;

public sealed class ApplicationInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IInvestmentCalculator, CdbInvestmentCalculator>();
    }
}
