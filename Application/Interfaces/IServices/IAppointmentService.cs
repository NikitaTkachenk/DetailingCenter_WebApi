using Application.DTO.Appointment;
using Application.DTO.Client;

namespace Application.Interfaces.IServices;

public interface IAppointmentService
{
    public Task<IEnumerable<ResponseAppointmentDTO>> GetAllAsync();
    
    public Task<ResponseAppointmentDTO> GetByIdAsync(int id);
    
    public Task CreateAsync(CreateAppointmentDTO clientDto);
    
    public Task UpdateAsync(int id, UpdateAppointmentDTO clientDto);
    
    public Task DeleteByIdAsync(int id);
}