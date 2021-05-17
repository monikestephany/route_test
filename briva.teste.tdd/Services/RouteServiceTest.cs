using brivva.teste.core.Entities;
using brivva.teste.core.Interfaces.Data;
using brivva.teste.core.Interfaces.Service;
using brivva.teste.core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace brivva.teste.tdd.Services
{
    public class RouteServiceTest
    {
        private readonly RouteService _routeService;
        private readonly Mock<IRouteFile> _moqRouteFile;
        private readonly List<Route> listRoute;
        private readonly Route routeSucess;
        private readonly Route routeError;
        private readonly Route routeNotOrigin;
        private readonly Route routeNotDestiny;
        public RouteServiceTest()
        {
            routeSucess = new Route { Origin = "GRU", Destiny = "BRC" };
            routeError = new Route { Origin = "GRU", Destiny = "ORL" };
            routeNotOrigin = new Route { Origin = "", Destiny = "BRC" };
            routeNotDestiny = new Route { Origin = "GRU", Destiny = "" };
            _moqRouteFile = new Mock<IRouteFile>();
            _routeService = new RouteService(_moqRouteFile.Object);
            listRoute = new List<Route>
                {
                    new Route
                    {
                        Origin = "GRU",
                        Destiny = "BRC",
                        Stops = new List<string> { "ORL" },
                        Value = 52
                    },
                    new Route
                    {
                        Origin = "GRU",
                        Destiny = "BRC",
                        Stops = new List<string> { "SCL", "CDG", "ORL" },
                        Value = 30
                    }
                };
        }
        #region Method BestValueRoute
        [Fact]
        public void BestValueRouteTestSucess()
        {
            _moqRouteFile.Setup(p => p.GetAllRouteFile()).Returns(listRoute); 
            var result = _routeService.BestValueRoute(routeSucess);
            Assert.Equal("best route: GRU - SCL - CDG - ORL - BRC > 30", result);
        }
        [Fact]
        public void BestValueRouteTestNotExistsRoute()
        {
            _moqRouteFile.Setup(p => p.GetAllRouteFile()).Returns(listRoute);
            var result = _routeService.BestValueRoute(routeError);
            Assert.Equal("not exist route the origin for destiny", result);
        }
        [Fact]
        public void BestValueRouteTestNotExistFile()
        {
            _moqRouteFile.Setup(p => p.GetAllRouteFile()).Throws(new Exception("File not exists"));
            var exception = Assert.Throws<Exception>(() => _routeService.BestValueRoute(routeError));
            Assert.Equal("File not exists", exception.Message);
        }
        [Fact]
        public void BestValueRouteTestOriginNullOrEmpty()
        {
            _moqRouteFile.Setup(p => p.GetAllRouteFile()).Returns(listRoute);
            var exception = Assert.Throws<Exception>(() => _routeService.BestValueRoute(routeNotOrigin));
            Assert.Equal("Origin is mandatory!", exception.Message);
        }
        [Fact]
        public void BestValueRouteTestDestinyNullOrEmpty()
        {
            _moqRouteFile.Setup(p => p.GetAllRouteFile()).Returns(listRoute);
            var exception = Assert.Throws<Exception>(() => _routeService.BestValueRoute(routeNotDestiny));
            Assert.Equal("Destiny is mandatory!", exception.Message);
        }
        #endregion

        #region Method CreateRoute
        [Fact]
        public void CreateRouteTest()
        {
            _moqRouteFile.Setup(p => p.InputRouteFile(routeSucess)).Returns(true);
            Assert.True(_routeService.CreateRoute(routeSucess));
        }

        [Fact]
        public void CreateRouteTestFileNotExists()
        {
            _moqRouteFile.Setup(p => p.InputRouteFile(routeSucess)).Throws(new Exception("File not exists"));
            var exception = Assert.Throws<Exception>(() => _routeService.CreateRoute(routeSucess));
            Assert.Equal("File not exists", exception.Message);
        }

        [Fact]
        public void CreateRouteTestOriginNotNullOrEmpty()
        {
            _moqRouteFile.Setup(p => p.InputRouteFile(routeSucess)).Throws(new Exception("File not exists"));
            var exception = Assert.Throws<Exception>(() => _routeService.CreateRoute(routeNotOrigin));
            Assert.Equal("Origin is mandatory!", exception.Message);
        }

        [Fact]
        public void CreateRouteTestDestinyNotNullOrEmpty()
        {
            _moqRouteFile.Setup(p => p.InputRouteFile(routeSucess)).Throws(new Exception("File not exists"));
            var exception = Assert.Throws<Exception>(() => _routeService.CreateRoute(routeNotDestiny));
            Assert.Equal("Destiny is mandatory!", exception.Message);
        }
        #endregion

        [Fact]
        public void ValidRouteTestSucess() 
        {
            string route = "GRU-BRC";
            var newRoute =_routeService.ValidRoute(route);
            Assert.Equal(routeSucess.Origin, newRoute.Origin);
            Assert.Equal(routeSucess.Destiny, newRoute.Destiny);
        }
        [Fact]
        public void ValidRouteTestFormatError()
        {
            string route = "GRU-BRC-OOO";
            var exception = Assert.Throws<Exception>(() => _routeService.ValidRoute(route));
            Assert.Equal("format is not valid", exception.Message);

            string route2 = "GRU-BRCM";
            var exception2 = Assert.Throws<Exception>(() => _routeService.ValidRoute(route2));
            Assert.Equal("format is not valid", exception2.Message);
        }
      

    }
}
