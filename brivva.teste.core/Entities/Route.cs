using brivva.teste.core.Validators;
using ServiceStack.FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace brivva.teste.core.Entities
{
    [Validator(typeof(RouteValidate))]
    public class Route
    {
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public  List<string> Stops { get; set; }
        public decimal Value { get; set; }
    }
}
