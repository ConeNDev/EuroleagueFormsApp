using Entity.Models.BaseEntityModel;
using Entity;
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
    public class GetAllPlayerSystemOperationTests
    {
        private readonly GetAllPlayerSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public GetAllPlayerSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new GetAllPlayerSystemOperation
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_FillsPlayerListWithPlayersFromRepository()
        {
            // Arrange
            var playerList = new List<Player>
            {
                new Player { PlayerId = 1, FirstName = "Nemanja",LastName="Nedovic" },
                new Player { PlayerId = 2, FirstName = "Nikola", LastName="Kalinic" }
            };

            // Simulacija da repozitorijum vraća listu igrača
            mockRepository.Setup(r => r.Select(It.IsAny<Player>())).Returns(playerList.Cast<IEntity>().ToList());

            // Act
            operation.Execute();

            // Assert
            Assert.NotNull(operation.PlayerList);
            Assert.Equal(2, operation.PlayerList.Count);
            Assert.Equal(1, operation.PlayerList[0].PlayerId);
            Assert.Equal(2, operation.PlayerList[1].PlayerId);

            // Provera da li je metoda Select pozvana jednom
            mockRepository.Verify(r => r.Select(It.IsAny<Player>()), Times.Once);
        }
    }
}
