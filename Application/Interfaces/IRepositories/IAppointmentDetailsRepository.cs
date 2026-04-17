using Domain;

namespace Application.Interfaces.IRepositories;

public interface IAppointmentDetailsRepository
{
    public Task<IEnumerable<AppointmentDetails>> GetAllAsync();
    
    public Task<AppointmentDetails?> GetByAppointmentIdAsync(int id);
    
    public Task AddAsync(AppointmentDetails appointmentDetails);
    
    public Task UpdateAsync(AppointmentDetails appointmentDetails);
    
    public Task DeleteByIdAsync(int id);
}