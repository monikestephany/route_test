using brivva.teste.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace brivva.teste.core.Interfaces.Data
{
    public interface IRouteFile
    {
        IEnumerable<Route> GetAllRouteFile();
        bool InputRouteFile(Route route);
    }
}
