using Application.DTO.Appointment;
using Application.DTO.AppointmentDetails;
using Application.DTO.Client;
using Application.Filters;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain;

namespace Application.Services;

internal class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    
    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<ResponseClientDTO>> GetAllAsync(ClientFilter filter)
    {
        var clients = await _repository.GetAllAsync(filter);
        
        var _clientsResponse = clients.Select(x => new ResponseClientDTO
        {
            Name = x.Name,
            LastName = x.LastName,
            Age = x.Age,
            Email = x.Email,
            
            Appointments = x.Appointments.Select(a => new ResponseAppointmentDTO
            {
                ClientId = a.ClientId,
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

    public async Task<ResponseClientDTO?> GetByIdAsync(int id)
    {
        var client = await _repository.GetByIdAsync(id);

        if (client is null)
            return null;

        var clientById = new ResponseClientDTO
        {
            Name = client.Name,
            LastName = client.LastName,
            Age = client.Age,
            Email = client.Email,
            
            Appointments = client.Appointments.Select(a => new ResponseAppointmentDTO
            {
                ClientId = a.ClientId,
                Name = a.Name,
                AppointmentDetails = new ResponseAppointmentDetailsDTO
                {
                    Description = a.AppointmentDetails.Description,
                    Price = a.AppointmentDetails.Price,
                    AppointmentAt = a.AppointmentDetails.AppointmentAt
                }
            }).ToList()
        };
        
        return clientById;
    }

    public async Task AddAsync(CreateClientDTO clientDto)
    {
        var newClient = new Client
        {
            Name = clientDto.Name,
            LastName = clientDto.LastName,
            Email = clientDto.Email,
            Age = clientDto.Age
        };
        
        await _repository.AddAsync(newClient);
        await _repository.SaveInfo();
    }

    public async Task UpdateAsync(int id, UpdateClientDTO clientDto)
    {
        var client = await _repository.GetByIdAsync(id);

        if (client is not null)
        {
            client.Name = clientDto.Name;
            client.LastName = clientDto.LastName;
            client.Age = clientDto.Age;
            client.Email = clientDto.Email;
        }
        else
            return;
        
        await _repository.UpdateAsync(client);
        await _repository.SaveInfo();
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _repository.DeleteByIdAsync(id);
        await _repository.SaveInfo();
    }
}