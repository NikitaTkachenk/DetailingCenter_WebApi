using Application.DTO.Client;
using Domain;

namespace Application.Interfaces.IServices;

public interface IClientService
{
    public Task<IEnumerable<ResponseClientDTO>> GetAllAsync();
    
    public Task<ResponseClientDTO?>  GetByIdAsync(int id);
    
    public Task AddAsync(CreateClientDTO clientDto);
    
    public Task UpdateAsync(UpdateClientDTO clientDto);
    
    public Task DeleteByIdAsync(int id);
}