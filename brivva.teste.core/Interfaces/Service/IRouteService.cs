using brivva.teste.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace brivva.teste.core.Interfaces.Service
{
    public interface IRouteService
    {
        string BestValueRoute(Route route);
        bool CreateRoute(Route route);

        Route ValidRoute(string route);
    }
}
