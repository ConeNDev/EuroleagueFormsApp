using Entity.Models.BaseEntityModel;
using Entity.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.SystemOperations;
using Repository.Repository;
namespace SystemOperations.Tests
{
    public class GetAllCitiesWithTeamsTests
    {
        private readonly GetAllCitiesWithTeams operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public GetAllCitiesWithTeamsTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new GetAllCitiesWithTeams
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_FillsCitiesListWithCitiesFromRepository()
        {
            // Arrange
            var cityList = new List<City>
            {
                new City { CityId = 1, Name = "Belgrade" },
                new City { CityId = 2, Name = "Novi Sad" }
            };

           
            mockRepository.Setup(r => r.Select(It.IsAny<City>())).Returns(cityList.Cast<IEntity>().ToList());

            // Act
            operation.Execute();

            // Assert
            Assert.NotNull(operation.Cities);
            Assert.Equal(2, operation.Cities.Count);
            Assert.Equal("Belgrade", operation.Cities[0].Name);
            Assert.Equal("Novi Sad", operation.Cities[1].Name);

          
            mockRepository.Verify(r => r.Select(It.IsAny<City>()), Times.Once);
        }
    }
}
