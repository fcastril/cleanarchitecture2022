using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MainContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IOptionRepository, OptionRepository>();
            services.AddScoped<IOptionSecurityRepository, OptionSecurityRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserCompanyProfileRepository, UserCompanyProfileRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;

        }
    }
}
