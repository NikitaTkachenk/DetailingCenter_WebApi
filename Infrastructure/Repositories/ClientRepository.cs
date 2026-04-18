using Application.Interfaces.IRepositories;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public ClientRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _applicationDbContext.Clients.Include(x => x.Appointments)
                                                                  .ThenInclude(x => x.AppointmentDetails)
                                                                  .AsNoTracking()
                                                                  .ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _applicationDbContext.Clients.Include(x => x.Appointments)
                                                        .ThenInclude(x => x.AppointmentDetails)
                                                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Client client)
    {
        await _applicationDbContext.Clients.AddAsync(client);
    }

    public Task UpdateAsync(Client client)
    {
        _applicationDbContext.Clients.Update(client);
        return Task.CompletedTask;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var client = await _applicationDbContext.Clients.FindAsync(id);
        
        if(client is not null)
            _applicationDbContext.Clients.Remove(client);
    }
}