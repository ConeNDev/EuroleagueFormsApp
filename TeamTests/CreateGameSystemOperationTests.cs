using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Entity.Models;
using Repository.Repository;
using SystemOperations.SystemOperations;
using Xunit;
using Entity.Models.BaseEntityModel;
using Entity;

namespace GameTests
{
    public class CreateGameSystemOperationTests
    {
        [Fact]
        public void ExecuteConcreteOperation_ShouldThrowException_WhenGameIsNull()
        {
            // Arrange
            var mockRepo = new Mock<GenericDbRepository>();
            var createGameOperation = new CreateGameSystemOperation
            {
                Game = null, // Game je null
                repository = mockRepo.Object // Mockovan repozitorijum
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => createGameOperation.Execute());
            Assert.Equal("Game is null", exception.Message);

            // Proveri da nije pozvao repozitorijum
            mockRepo.Verify(r => r.Insert(It.IsAny<Game>()), Times.Never);
        }


        [Fact]
        public void ExecuteConcreteOperation_ShouldThrowException_WhenGameAlreadyExists()
        {
            // Arrange
            var mockRepo = new Mock<GenericDbRepository>();

            var existingGame = new Game { Team1 = new Team { Name = "Team A" }, Team2 = new Team { Name = "Team B" }, GameTime = DateTime.Now };
            mockRepo.Setup(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()))
                    .Returns(new List<IEntity> { existingGame }); // Vraća igru koja već postoji

            var createGameOperation = new CreateGameSystemOperation
            {
                Game = existingGame,
                repository = mockRepo.Object
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => createGameOperation.Execute());
            Assert.Equal("System can't create that game, because it already exists", exception.Message);

            // Proveri da nije pozvao Insert
            mockRepo.Verify(r => r.Insert(It.IsAny<Game>()), Times.Never);
        }


        [Fact]
        public void ExecuteConcreteOperation_ShouldCreateGame_WhenGameDoesNotExist()
        {
            // Arrange
            var mockRepo = new Mock<GenericDbRepository>();

            var newGame = new Game
            {
                Team1 = new Team { Name = "Team A" },
                Team2 = new Team { Name = "Team B" },
                GameTime = DateTime.Now,
                PlayersStatsList = new List<PlayerStatistics>
        {
            new PlayerStatistics { PlayerId = 1 },
            new PlayerStatistics { PlayerId = 2 }
        }
            };

            // Nema igara u bazi sa istim timovima i vremenom
            mockRepo.Setup(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()))
                    .Returns(new List<IEntity>());

            var createGameOperation = new CreateGameSystemOperation
            {
                Game = newGame,
                repository = mockRepo.Object
            };

            // Act
            createGameOperation.Execute();

            // Assert
            mockRepo.Verify(r => r.Insert(It.Is<Game>(g => g == newGame)), Times.Once);
            mockRepo.Verify(r => r.Insert(It.Is<PlayerStatistics>(ps => ps.GameId == newGame.GameId)), Times.Exactly(newGame.PlayersStatsList.Count));
            mockRepo.Verify(r => r.Commit(), Times.Once);
        }

    }
}
