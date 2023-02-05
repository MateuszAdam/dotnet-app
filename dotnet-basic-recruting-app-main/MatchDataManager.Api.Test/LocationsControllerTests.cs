using MatchDataManager.Api.Controllers;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;
using Assert = Xunit.Assert;

namespace MatchDataManager.Api.Test
{
    [TestClass]
    public class LocationsControllerTests 
    {
        private readonly Mock<ILocationsRepository> _locationRepositoryMock;
        private readonly LocationsController _controller;

        public LocationsControllerTests()
        {
            _locationRepositoryMock = new Mock<ILocationsRepository>();
            _controller = new LocationsController(_locationRepositoryMock.Object);
        }


        [TestMethod]
        public void GetLocationById_should_return_BadRequestCode()
        {
            // Arrange            
            var model = new LocationModel() { Id = 1, Name = "Silesia", City = "Katowice" };
            _locationRepositoryMock.Setup(c => c.AddLocation(model));

            // Act
           var result = _controller.GetById(5);

            // Assert
            Assert.Equal(typeof(Microsoft.AspNetCore.Mvc.NotFoundResult), result.Result.GetType());
        }


        [TestMethod]
        public void AddLocation_should_return_id_after_successful_save()
        {
            // Arrange
            var model = new LocationModel() { Id = 1, Name = "Silesia", City= "Katowice" };
            _locationRepositoryMock.Setup(c => c.AddLocation(model));

            // Act
            var result = _controller.AddLocation(model);

            //Assert
            Assert.NotEqual(typeof(BadRequestResult), result.Result.GetType());
        }
    }
}