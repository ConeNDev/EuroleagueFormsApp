using Entity.Models.BaseEntityModel;
using Entity;
using Moq;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.SystemOperations;

namespace SystemOperations.Tests
{
    public class SearchGameSystemOperationTests
    {
        private readonly SearchGameSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public SearchGameSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new SearchGameSystemOperation
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_FilterIsNull_ReturnsAllGames()
        {
            // Arrange
            var allGames = new List<Game>
            {
                new Game { GameId = 1, Team1 = new Team { Name = "Team A" }, Team2 = new Team { Name = "Team B" }, GameTime = DateTime.Now },
                new Game { GameId = 2, Team1 = new Team { Name = "Team C" }, Team2 = new Team { Name = "Team D" }, GameTime = DateTime.Now }
            };

            // Simulacija da repozitorijum vraća све игре када нема филтера
            mockRepository.Setup(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()))
                .Returns(allGames.Cast<IEntity>().ToList());

            operation.filter = null;

            // Act
            operation.Execute();

            // Assert
            Assert.NotNull(operation.filteredGames);
            Assert.Equal(2, operation.filteredGames.Count);
            Assert.Equal(1, operation.filteredGames[0].GameId);
            Assert.Equal(2, operation.filteredGames[1].GameId);

            mockRepository.Verify(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ExecuteConcreteOperation_FilterMatches_ReturnsFilteredGames()
        {
            // Arrange
            var filteredGames = new List<Game>
            {
                new Game { GameId = 1, Team1 = new Team { Name = "Team A" }, Team2 = new Team { Name = "Team B" }, GameTime = DateTime.Now }
            };

            operation.filter = "Team A";

            // Simulacija да repozitorijum враћа филтриране игре
            mockRepository.Setup(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()))
                .Returns(filteredGames.Cast<IEntity>().ToList());

            // Act
            operation.Execute();

            // Assert
            Assert.NotNull(operation.filteredGames);
            Assert.Single(operation.filteredGames);
            Assert.Equal(1, operation.filteredGames[0].GameId);
            Assert.Equal("Team A", operation.filteredGames[0].Team1.Name);

            mockRepository.Verify(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ExecuteConcreteOperation_FilterDoesNotMatch_ReturnsNoGames()
        {
            // Arrange
            operation.filter = "NonExistingTeam";

            // Simulacija да repozitorijum враћа празну листу када нема подударања
            mockRepository.Setup(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()))
                .Returns(new List<IEntity>());

            // Act
            operation.Execute();

            // Assert
            Assert.NotNull(operation.filteredGames);
            Assert.Empty(operation.filteredGames);

            mockRepository.Verify(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()), Times.Once);
        }
    }
}
