using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Entity.Models;
using Repository.Repository;
using SystemOperations.SystemOperations;
using Xunit;

namespace GameTests
{
    public class CreateGameSystemOperationTests
    {
        [Fact]
        public void ExecuteConcreteOperation_ShouldInsertGame_WhenGameIsValid()
        {
            // Arrange
            var mockRepository = new Mock<GenericDbRepository>();
            var newGame = new Game { Team1 = new Team { Name = "Team A" }, Team2 = new Team { Name = "Team B" }, GameTime = DateTime.Now };

            // Return empty list to indicate no existing game
            mockRepository.Setup(repo => repo.Select(It.IsAny<Game>(), It.IsAny<string>()))
                          .Returns(new List<IEntity>());

            var createGameSO = new CreateGameSystemOperation
            {
                repository = mockRepository.Object,
                Game = newGame
            };

            // Act
            createGameSO.Execute();

            // Assert
            mockRepository.Verify(repo => repo.Insert(It.Is<Game>(g => g.Team1.Name == "Team A" && g.Team2.Name == "Team B")), Times.Once);
            mockRepository.Verify(repo => repo.Commit(), Times.Once);
        }

        [Fact]
        public void ExecuteConcreteOperation_ShouldThrowException_WhenGameAlreadyExists()
        {
            // Arrange
            var mockRepository = new Mock<GenericDbRepository>();
            var existingGame = new Game { Team1 = new Team { Name = "Team A" }, Team2 = new Team { Name = "Team B" }, GameTime = DateTime.Now };
            var newGame = new Game { Team1 = new Team { Name = "Team A" }, Team2 = new Team { Name = "Team B" }, GameTime = DateTime.Now };

            // Simulate existing game
            mockRepository.Setup(repo => repo.Select(It.IsAny<Game>(), It.IsAny<string>()))
                          .Returns(new List<IEntity> { existingGame });

            var createGameSO = new CreateGameSystemOperation
            {
                repository = mockRepository.Object,
                Game = newGame
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => createGameSO.Execute());
            Assert.Equal("System can't create that game, because it already exists", exception.Message);
        }

        [Fact]
        public void ExecuteConcreteOperation_ShouldThrowException_WhenGameIsNull()
        {
            // Arrange
            var mockRepository = new Mock<GenericDbRepository>();

            var createGameSO = new CreateGameSystemOperation
            {
                repository = mockRepository.Object,
                Game = null
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => createGameSO.Execute());
            Assert.Equal("Game is null", exception.Message);
        }
    }
}
