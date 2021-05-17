using brivva.teste.core.Entities;
using brivva.teste.core.Interfaces.Data;
using brivva.teste.core.Interfaces.Service;
using brivva.teste.core.Validators;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace brivva.teste.core.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteFile _routeFile;
        private readonly RouteValidate routeValidate;

        public RouteService(IRouteFile routeFile)
        {
            _routeFile = routeFile;
            routeValidate = new RouteValidate();
        }
        public bool CreateRoute(Route route)
        {
            if (route == null)
            {
                throw new Exception("The json te route is not valid.");
            }

            routeValidate.Validate(route);
          
            return _routeFile.InputRouteFile(route);
        }
        public string BestValueRoute(Route route)
        {
            routeValidate.Validate(route);

            var routes = _routeFile.GetAllRouteFile();
            var bestRoute = routes.Where(p => p.Origin == route.Origin && p.Destiny == route.Destiny).OrderBy(p => p.Value).FirstOrDefault();
            if (bestRoute == null)
            {
                return "not exist route the origin for destiny";
            }
         
            var stops = bestRoute.Stops != null ? String.Join(" - ", bestRoute.Stops.ToArray()) : null;
            return stops != null ? $"best route: {bestRoute.Origin} - {stops} - {bestRoute.Destiny} > {bestRoute.Value}" :
                $"best route: {bestRoute.Origin} - {bestRoute.Destiny} > {bestRoute.Value}";
        }

        public Route ValidRoute(string route)
        {
            var newRoute = new Route();
            route.Trim();
            var splits = route.Split('-');
            if (splits.Length != 2)
            {
                throw new Exception("format is not valid");
            }
            foreach (var split in splits)
            {
                split.Trim();
                if (split.Length > 3)
                {
                    throw new Exception("format is not valid");
                }
            }
            newRoute.Origin = splits[0];
            newRoute.Destiny = splits[1];
            return newRoute;
        }
    }
}
