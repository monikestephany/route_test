using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using brivva.teste.api.Models;
using brivva.teste.core.Entities;
using brivva.teste.core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Filters;

namespace brivva.teste.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRouteService _routeService;

        public RouteController(IMapper mapper, IRouteService routeService)
        {
            _mapper = mapper;
            _routeService = routeService;
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(RouteModel), typeof(RouteModel))]
        public IActionResult PostRoute([FromBody]RouteModel routeModel)
        {
            var entitie = _mapper.Map<Route>(routeModel);
            return Created("Rota Criada", _routeService.CreateRoute(entitie));
        }
    }
}