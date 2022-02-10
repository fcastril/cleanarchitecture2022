using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Seeds
{
    public class CompanySeed
    {
        public static async Task SeedAsync(MainContext context, ILogger<CompanySeed> logger)
        {
            if (!context.Companies.Any())
            {
                context.Companies.AddRange(GetPreconfiguredCompany());
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
