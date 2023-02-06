using MatchDataManager.Api.Controllers;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Assert = Xunit.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

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
        public async Task Get_All_Locations_Success_Test_returns_list_of_locations()
        {
            //arrange
            var LocationsList = new List<LocationModel>
            {
                new LocationModel
                {
                    Id = 1,
                    Name = "California",
                    City = "San Francisco"
                },
                 new LocationModel
                {
                    Id = 2,
                    Name = "Italia",
                    City = "Lecce"
                },
                 new LocationModel
                {
                    Id = 3,
                    Name = "Canaries",
                    City = "Las Palmas"
                }
            };

            _locationRepositoryMock.Setup(x => x.GetAllLocations()).Returns(Task.FromResult(LocationsList as ICollection<LocationModel>));

            //act
            var contentResult = await _controller.GetAllLocations();

            //assert
            CollectionAssert.AreEqual(LocationsList, (contentResult as OkObjectResult)!.Value as List<LocationModel>);
        }

        [TestMethod]
        public async Task Get_All_Locations_returns_Empty_list_of_locations_withCode_NoContent()
        {
            //arrange
            var LocationsList = new List<LocationModel>();            

            _locationRepositoryMock.Setup(x => x.GetAllLocations()).Returns(Task.FromResult(LocationsList as ICollection<LocationModel>));

            //act
            var contentResult = await _controller.GetAllLocations();

            //assert
            Assert.Equal(typeof(NoContentResult), contentResult.GetType());
        }

        [TestMethod]
        public void GetLocationById_should_return_location_success()
        {
            // Arrange            
            var model = new LocationModel() { Id = 1, Name = "Silesia", City = "Katowice" };
            _locationRepositoryMock.Setup(c => c.GetLocationById(1)).Returns(Task.FromResult(model));
            
            // Act
            var result = _controller.GetById(1);

            // Assert
            Assert.Equal(typeof(OkObjectResult), result.Result.GetType());
        }

        [TestMethod]
        public void GetLocationById_should_return_NotFound()
        {
            var model = new LocationModel() { Id = 1, Name = "Silesia", City = "Katowice" };
            _locationRepositoryMock.Setup(c => c.GetLocationById(1)).Returns(Task.FromResult(model));
            
            // Act
            var result = _controller.GetById(2);

            // Assert
            Assert.Equal(typeof(NotFoundResult), result.Result.GetType());
        }


        [TestMethod]
        public void AddLocation_should_return_id_1_after_successful_save()
        {
            // Arrange
            var model = new LocationModel() { Id = 1, Name = "Silesia", City= "Katowice" };
            _locationRepositoryMock.Setup(c => c.AddLocation(model)).Returns(Task.FromResult(1));

            // Act
            var result = _controller.AddLocation(model);

            Assert.Equal(1, result.Id);
        }


        [TestMethod]
        public void AddLocation_should_return_badRequest_after_failed_save()
        {
            // Arrange
            var model = new LocationModel() { Id = 1, Name = "", City = "Katowice" };
            _locationRepositoryMock.Setup(c => c.AddLocation(model)).Returns(Task.FromResult(0));

            // Act
            var result = _controller.AddLocation(model);

            Assert.Equal(typeof(BadRequestObjectResult), result.Result.GetType());
        }

        [TestMethod]
        public void UpdateLocation_should_return_notFoundCode_after_invalid_update()
        {
            // Arrange
            var model = new LocationModel() { Id = 21, Name= String.Empty, City = "Katowice" };
            _locationRepositoryMock.Setup(c => c.AddLocation(model)).Returns(Task.FromResult(default(int)));
           
            // Act
            var result = _controller.UpdateLocation(model);

            //Assert
            Assert.Equal(typeof(NotFoundObjectResult), result.Result.GetType());
        }

        [TestMethod]
        public void UpdateLocation_should_return_OkCode_after_successful_update()
        {
            // Arrange
            var existingModel = new LocationModel() { Id = 1, Name = "Silesia", City = "Katowice" };
            var model = new LocationModel() { Id = 1, Name = "Polska", City = "Katowice" };
            _locationRepositoryMock.Setup(c => c.AddLocation(existingModel)).Returns(Task.FromResult(1));
            _locationRepositoryMock.Setup(c => c.UpdateLocation(model)).Returns(Task.FromResult(1));

            // Act
            var result = _controller.UpdateLocation(model);

            //Assert
            Assert.Equal(typeof(OkObjectResult), result.Result.GetType());
        }

    }
}