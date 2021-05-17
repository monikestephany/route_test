using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brivva.teste.api.Models
{
    public class RouteModel
    {
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public List<string> Stops { get; set; }
        public decimal Value { get; set; }
    }
}
