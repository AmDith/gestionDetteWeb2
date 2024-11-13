using Cours.Data;
using Cours.Models;
using Cours.Services;
using Microsoft.EntityFrameworkCore;

namespace gestionDetteWeb2.Services.Impl;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        // Your implementation to fetch clients from your data source
        return await _context.Clients.ToListAsync();
    }
}