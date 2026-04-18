using Application.DTO.Appointment;
using Application.DTO.AppointmentDetails;
using Application.DTO.Client;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;

namespace Application.Services;

internal class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    
    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<ResponseClientDTO>> GetAllAsync()
    {
        var clients = await _repository.GetAllAsync();
        
        var _clientsResponse = clients.Select(x => new ResponseClientDTO
        {
            Name = x.Name,
            LastName = x.LastName,
            Age = x.Age,
            Email = x.Email,
            
            Appointments = x.Appointments.Select(a => new ResponseAppointmentDTO
            {
                Name = a.Name,
                AppointmentDetails = new ResponseAppointmentDetailsDTO
                {
                    Description = a.AppointmentDetails.Description,
                    Price = a.AppointmentDetails.Price,
                    AppointmentAt = a.AppointmentDetails.AppointmentAt
                }
            }).ToList()
        });
        return _clientsResponse;
    }

    public Task<ResponseClientDTO?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(CreateClientDTO clientDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateClientDTO clientDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}