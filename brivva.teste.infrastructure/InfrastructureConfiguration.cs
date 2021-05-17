using brivva.teste.core.Interfaces.Data;
using brivva.teste.core.Interfaces.Service;
using brivva.teste.core.Services;
using brivva.teste.data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace brivva.teste.infrastructure
{
    public static class InfrastructureConfiguration 
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRouteFile, RouteFile>();
            services.AddScoped<IRouteService, RouteService>();
        }
        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
