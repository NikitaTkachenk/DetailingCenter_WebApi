using Domain;

namespace Application.Interfaces.IRepositories;

public interface IAppointmentRepository
{
    public Task<IEnumerable<Appointment>> GetAllAsync();
    
    public Task<Appointment?> GetByIdAsync(int id);
    
    public Task AddAsync(Appointment appointment);
    
    public Task UpdateAsync(Appointment appointment);
    
    public Task DeleteByIdAsync(int id);
}