namespace Gauss.InvestmentCalculator.Api.Installers;

public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
