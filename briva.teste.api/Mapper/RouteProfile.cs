using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using brivva.teste.api.Models;
using brivva.teste.core.Entities;

namespace brivva.teste.api.Mapper
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<RouteModel, Route>();
        }
    }
}
