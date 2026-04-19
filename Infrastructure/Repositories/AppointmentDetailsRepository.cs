using Application.Interfaces.IRepositories;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class AppointmentDetailsRepository : IAppointmentDetailsRepository
{
    private readonly ApplicationDbContext  _applicationDbContext;

    public AppointmentDetailsRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<AppointmentDetails>> GetAllAsync()
    {
        return await _applicationDbContext.AppointmentDetails.AsNoTracking().ToListAsync();
    }

    public async Task<AppointmentDetails?> GetByAppointmentIdAsync(int id)
    {
        return await _applicationDbContext.AppointmentDetails.FirstOrDefaultAsync(x => x.AppointmentId == id);
    }

    public async Task AddAsync(AppointmentDetails appointmentDetails)
    {
        await _applicationDbContext.AppointmentDetails.AddAsync(appointmentDetails);
    }

    public Task UpdateAsync(AppointmentDetails appointmentDetails)
    {
        _applicationDbContext.AppointmentDetails.Update(appointmentDetails);
        return Task.CompletedTask;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var appointmentDetails = await _applicationDbContext.AppointmentDetails.FindAsync(id);
        
        if(appointmentDetails is not null)
            _applicationDbContext.AppointmentDetails.Remove(appointmentDetails);
    }
    
    public async Task SaveInfo()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}