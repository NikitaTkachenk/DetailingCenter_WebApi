using Application.Filters;
using Application.Interfaces.IRepositories;
using Domain;
using Infrastructure.Data;
using Infrastructure.ExtentionFilters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public  AppointmentRepository(ApplicationDbContext  applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<Appointment>> GetAllAsync(AppointmentFilter filter)
    {
        return await _applicationDbContext.Appointments.Include(x => x.AppointmentDetails)
                                                       .ApplyFilters(filter)
                                                       .AsNoTracking()
                                                       .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)
    {
        return await _applicationDbContext.Appointments.Include(x => x.AppointmentDetails)
                                                       .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _applicationDbContext.Appointments.AddAsync(appointment);
    }

    public Task UpdateAsync(Appointment appointment)
    {
        _applicationDbContext.Appointments.Update(appointment);
        return Task.CompletedTask;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var appointment = await _applicationDbContext.Appointments.FindAsync(id);
        
        if(appointment is not null)
            _applicationDbContext.Appointments.Remove(appointment);
    }
    
    public async Task SaveInfo()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}