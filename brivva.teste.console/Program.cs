using brivva.teste.core.Interfaces.Data;
using brivva.teste.core.Interfaces.Service;
using brivva.teste.infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace brivva.teste.console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IServiceCollection services = new ServiceCollection();
                services.ConfigureDependencyInjection();
                var Configuration = InfrastructureConfiguration.LoadConfiguration();
                services.AddSingleton(Configuration);
                var serviceProvider = services.BuildServiceProvider();
                var routeServices = serviceProvider.GetService<IRouteService>();

                Console.WriteLine("please enter the route:");

                var route = Console.ReadLine();
                var newRoute =routeServices.ValidRoute(route);
                Console.WriteLine(routeServices.BestValueRoute(newRoute));
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
