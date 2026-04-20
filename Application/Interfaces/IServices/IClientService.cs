using Application.DTO.Client;
using Application.Filters;
using Domain;

namespace Application.Interfaces.IServices;

public interface IClientService
{
    public Task<IEnumerable<ResponseClientDTO>> GetAllAsync(ClientFilter filter);
    
    public Task<ResponseClientDTO?>  GetByIdAsync(int id);
    
    public Task AddAsync(CreateClientDTO clientDto);
    
    public Task UpdateAsync(int id, UpdateClientDTO clientDto);
    
    public Task DeleteByIdAsync(int id);
}