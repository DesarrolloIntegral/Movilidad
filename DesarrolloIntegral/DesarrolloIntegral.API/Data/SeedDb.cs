using DesarrolloIntegral.Shared.Models;
using System.Diagnostics.Metrics;

namespace DesarrolloIntegral.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckBancosAsync();
        }

        private async Task CheckBancosAsync()
        {
            if (!_context.Bancos.Any())
            {
                _context.Bancos.Add(new Banco { NombreBanco = "Banamex", EstadoBanco= 1 });
                _context.Bancos.Add(new Banco { NombreBanco = "Bancomer", EstadoBanco = 1 });
            }

            await _context.SaveChangesAsync();
        }
    }
}
