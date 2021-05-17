using brivva.teste.core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace brivva.teste.core.Validators
{
    public class RouteValidate : AbstractValidator<Route>
    {
        public RouteValidate()
        {
            RuleFor(p => p.Origin).NotEmpty().NotNull().OnAnyFailure(p => throw new Exception("Origin is mandatory!"));
            RuleFor(p => p.Destiny).NotEmpty().NotNull().OnAnyFailure(p => throw new Exception("Destiny is mandatory!"));
        }
    }
}
