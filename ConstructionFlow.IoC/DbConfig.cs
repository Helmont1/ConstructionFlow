using ConstructionFlow.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConstructionFlow.IoC
{
    public static class DbConfig
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConstructionFlowDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                );

            return services;
        }
    }
}
