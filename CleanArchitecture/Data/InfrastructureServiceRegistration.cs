using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Models;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;

        }
    }
}
