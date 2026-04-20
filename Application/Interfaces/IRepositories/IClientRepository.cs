using Application.Filters;
using Domain;

namespace Application.Interfaces.IRepositories;

public interface IClientRepository
{
    public Task<IEnumerable<Client>> GetAllAsync(ClientFilter filter);
    
    public Task<Client?> GetByIdAsync(int id);
    
    public Task AddAsync(Client client);
    
    public Task UpdateAsync(Client client);
    
    public Task DeleteByIdAsync(int id);

    public Task SaveInfo();
}