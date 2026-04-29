using Gauss.InvestmentCalculator.Api.Installers;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.InstallServices(
    builder.Configuration, 
    typeof(Program).Assembly);

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options.WithTitle("GAUSS Investment Calculator API");
});

app.UseHttpsRedirection();

app.UseCors(CorsInstaller.PolicyName);

app.MapControllers();

app.Run();
