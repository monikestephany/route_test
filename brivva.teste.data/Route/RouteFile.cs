using brivva.teste.core.Entities;
using brivva.teste.core.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace brivva.teste.data.Context
{
    public class RouteFile : IRouteFile
    {
        private readonly string fullName;

        public RouteFile(IConfiguration configuration)
        {
            fullName = configuration.GetSection("PathRouteFile").Value;
        }

        public bool InputRouteFile(Route route)
        {
            if (!File.Exists(fullName))
            {
                throw new Exception("File not exists");
            }
            StringBuilder stringBuilder = new StringBuilder();
            List<string> linhas = File.ReadAllLines(fullName).ToList();

            stringBuilder.Append(route.Origin);
            stringBuilder.Append(",");
            if (route.Stops != null && route.Stops.Count > 0)
            {
                foreach (var stop in route.Stops)
                {
                    stringBuilder.Append(stop);
                    stringBuilder.Append(",");
                }
                stringBuilder.Append(route.Destiny);
            }
            else
            {
                stringBuilder.Append(route.Destiny);
            }
            stringBuilder.Append(",");
            stringBuilder.Append(route.Value.ToString());
            linhas.Insert(linhas.Count, stringBuilder.ToString());
            File.WriteAllLines(fullName, linhas);
            return true;
        }
        public IEnumerable<Route> GetAllRouteFile()
        {
            if (!File.Exists(fullName))
            {
                throw new Exception("File not exists");
            }

            var routes = new List<Route>();
            FileStream fileStream = new FileStream(fullName, FileMode.Open);
    
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split(',');
                    if (split.Length == 3)
                    {
                        routes.Add(RouteWithoutStops(split));
                    }
                    else
                    {
                        routes.Add(RouteWithStops(split));
                    }
                }
                return routes;
            }
        }
        private Route RouteWithStops(string[] split)
        {
            var route = new Route();
            route.Origin = split[0];
            route.Destiny = split[split.Length - 2];
            route.Value = Convert.ToDecimal(split[split.Length - 1]);
            route.Stops = new List<string>();
            for (int i = 0; i < split.Length - 1; i++)
            {
                if (i != 0 && i < split.Length - 2)
                {
                    route.Stops.Add(split[i]);
                }
            }
            return route;
        }
        private Route RouteWithoutStops(string[] split)
        {
            var route = new Route
            {
                Origin = split[0],
                Destiny = split[1],
                Value = Convert.ToDecimal(split[2])
            };
            return route;
        }
    }
}
