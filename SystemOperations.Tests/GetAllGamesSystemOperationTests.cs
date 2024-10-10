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
    public class GetAllGamesSystemOperationTests
    {
        private readonly GetAllGamesSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public GetAllGamesSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new GetAllGamesSystemOperation
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_FillsGameListWithGamesFromRepository()
        {
            // Arrange
            var gameList = new List<Game>
            {
                new Game { GameId = 1, Team1=new Team(){ Name="Crvena Zvezda" }, Team2=new Team(){ Name="Partizan" } },
                new Game { GameId = 2, Team1=new Team(){ Name="Olympiacos"}, Team2=new Team(){ Name="Panathinaikos"} }
            };

            // Simulacija da repozitorijum vraća listu igara
            mockRepository.Setup(r => r.Select(It.IsAny<Game>())).Returns(gameList.Cast<IEntity>().ToList());

            // Act
            operation.Execute();

            // Assert
            Assert.NotNull(operation.GameList);
            Assert.Equal(2, operation.GameList.Count);
            Assert.Equal("Crvena Zvezda", operation.GameList[0].Team1.Name);
            Assert.Equal("Olympiacos", operation.GameList[1].Team1.Name);

            // Provera da li je metoda Select pozvana jednom
            mockRepository.Verify(r => r.Select(It.IsAny<Game>()), Times.Once);
        }
    }
}
