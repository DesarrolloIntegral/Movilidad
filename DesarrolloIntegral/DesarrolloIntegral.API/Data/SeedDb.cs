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
                _context.Bancos.Add(new Banco 
                { 
                    Nombre = "Banamex", 
                    Estado = 1,
                    Cuentas = new List<CuentaBancaria>
                    {
                        new CuentaBancaria
                        {
                            NumeroCuenta = "4823-74315",
                            EstadoCuenta= 1, 
                        },
                        new CuentaBancaria
                        {
                            NumeroCuenta = "4823-123456",
                            EstadoCuenta= 1
                        }
                    }
                });
                _context.Bancos.Add(new Banco 
                { 
                    Nombre = "Bancomer", 
                    Estado = 1,
                    Cuentas = new List<CuentaBancaria>
                    {
                        new CuentaBancaria
                        {
                            NumeroCuenta = "0175-000123",
                            EstadoCuenta= 1
                        },
                        new CuentaBancaria
                        {
                            NumeroCuenta = "0175-000456",
                            EstadoCuenta= 1
                        }
                    }
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
