using Cours.Data;

namespace gestionDetteWeb2.Unicite.Impl
{
    public class ClientValidator : IClientValidator
    {
        private readonly ApplicationDbContext _context;

        public ClientValidator(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsUniqueTelephone(string telephone)
        {
            return !_context.Clients.Any(c => c.Telephone == telephone);
        }

        public bool IsUniqueSurname(string surname)
        {
            return !_context.Clients.Any(c => c.Surnom == surname);
        }
    }
}
