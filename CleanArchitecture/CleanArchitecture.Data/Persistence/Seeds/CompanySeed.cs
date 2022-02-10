using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence.Seeds
{
    public class CompanySeed
    {
        public static async Task SeedAsync(MainContext context, ILogger<CompanySeed> logger)
        {
            if (!context.Companies!.Any())
            {
                context.Companies!.AddRange(GetPreconfiguredCompany());
                await context.SaveChangesAsync();
            }
        }
        private static IEnumerable<Company> GetPreconfiguredCompany()
        {
            return new List<Company>{
                new Company
                {
                    Id = Guid.NewGuid(),
                    Code = "000",
                    Name = "Empresa de Prueba"

                }
            };
        }
    }
}
