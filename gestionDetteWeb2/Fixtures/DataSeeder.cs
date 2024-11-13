using Cours.Data;
using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionDetteWeb2.Fixtures;

public class DataSeeder
{
    private readonly ApplicationDbContext _context;

    public DataSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        // S'assurer que la base de données existe
        _context.Database.Migrate();

        // Ajouter les données si elles n'existent pas déjà
        if (!_context.Users.Any())
        {
            AddUsers();
        }

        if (!_context.Clients.Any())
        {
            AddClients();
        }

        if (!_context.Dettes.Any())
        {
            AddDettes();
        }

        _context.SaveChanges();
    }

    private void AddUsers()
    {
        var users = new List<User>
            {
                new User { Nom = "Admin", Prenom = "John", Login = "admin", Password = "admin123" },
                new User { Nom = "Doe", Prenom = "Jane", Login = "jane", Password = "password" }
            };

        _context.Users.AddRange(users);
    }

    private void AddClients()
    {
        var clients = new List<Client>
            {
                new Client { Surnom = "Client1", Telephone = "776123456", Adresse = "Dakar", UserId = 1 },
                new Client { Surnom = "Client2", Telephone = "778123456", Adresse = "Thies", UserId = 2 }
            };

        _context.Clients.AddRange(clients);
    }

    private void AddDettes()
    {
        var dettes = new List<Dette>
            {
                new Dette { Montant = 5000, MontantVerser = 2000, ClientId = 1 },
                new Dette { Montant = 10000, MontantVerser = 5000, ClientId = 2 }
            };

        _context.Dettes.AddRange(dettes);
    }
}
