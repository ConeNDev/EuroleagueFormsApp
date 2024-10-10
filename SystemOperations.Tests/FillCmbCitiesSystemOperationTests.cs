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
    public class FillCmbCitiesSystemOperationTests
    {
        private readonly FillCmbCitiesSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public FillCmbCitiesSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new FillCmbCitiesSystemOperation
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

            // Simulate repository returning the city list
            mockRepository.Setup(r => r.Select(It.IsAny<City>())).Returns(cityList.Cast<IEntity>().ToList());

            // Act
            operation.Execute();

            // Assert
            Assert.NotNull(operation.cities);
            Assert.Equal(2, operation.cities.Count);
            Assert.Equal("Belgrade", operation.cities[0].Name);
            Assert.Equal("Novi Sad", operation.cities[1].Name);

            // Verify that the repository Select method was called exactly once
            mockRepository.Verify(r => r.Select(It.IsAny<City>()), Times.Once);
        }
    }
}
