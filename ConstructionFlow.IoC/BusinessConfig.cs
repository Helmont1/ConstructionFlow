using ConstructionFlow.BL.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFlow.IoC
{
    public static class BusinessConfig
    {
        public static IServiceCollection AddBusinesses(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ActivityBusiness>();
            services.AddScoped<ConstructionBusiness>();
            services.AddScoped<ConstructionPhotoBusiness>();
            services.AddScoped<CustomerBusiness>();
            services.AddScoped<DefaultActivityBusiness>();
            services.AddScoped<StatusBusiness>();
            services.AddScoped<UserBusiness>();

            return services;
        }
    }
}
