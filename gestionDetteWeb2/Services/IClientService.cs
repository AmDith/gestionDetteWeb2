using Cours.Models;

namespace Cours.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsAsync();
}