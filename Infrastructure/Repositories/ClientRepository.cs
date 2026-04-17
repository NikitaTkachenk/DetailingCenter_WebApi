using Application.Interfaces.IRepositories;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    ApplicationDbContext _applicationDbContext;
    
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
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        _applicationDbContext.Clients.Remove(_applicationDbContext.Clients.FirstOrDefault(x => x.Id == id));
        await _applicationDbContext.SaveChangesAsync();
    }
}