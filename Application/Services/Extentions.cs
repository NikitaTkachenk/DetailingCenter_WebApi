using Application.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public static class Extentions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        return services;
    } 
}