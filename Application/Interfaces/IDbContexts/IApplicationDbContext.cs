using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.IDbContexts;

public interface IApplicationDbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentDetails> AppointmentDetails { get; set; }
}