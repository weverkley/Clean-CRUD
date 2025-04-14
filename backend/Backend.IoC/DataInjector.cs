using Backend.Infrastructure.Repositories;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Backend.Infrastructure.Contexts;

namespace Backend.IoC
{
    public static class DataInjector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // AddSingleton
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
