using Application.Interfaces.IDbContexts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentDetails> AppointmentDetails { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>();
        modelBuilder.Entity<Appointment>();
        modelBuilder.Entity<AppointmentDetails>();

        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentDetailsConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

class ClientConfiguration() : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Appointments).WithOne(x => x.Client).HasForeignKey(x => x.ClientId);
    }
}

class AppointmentConfiguration() : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AppointmentDetails).WithOne(x => x.Appointment).HasForeignKey<AppointmentDetails>(x => x.AppointmentId);
    }
}

class AppointmentDetailsConfiguration() : IEntityTypeConfiguration<AppointmentDetails>
{
    public void Configure(EntityTypeBuilder<AppointmentDetails> builder)
    {
        builder.HasOne(x => x.Appointment).WithOne(x => x.AppointmentDetails).HasForeignKey<AppointmentDetails>(x => x.AppointmentId);
    }
}

