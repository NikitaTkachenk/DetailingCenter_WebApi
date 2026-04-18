using Application.Interfaces.IRepositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data;

public static class Extentions
{
    public static IServiceCollection AddDataBase(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IAppointmentDetailsRepository, AppointmentDetailsRepository>();
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=detailingCenter_db;Username=postgres;Password=Nik2006151984_");
        });
        return services;
    }
}