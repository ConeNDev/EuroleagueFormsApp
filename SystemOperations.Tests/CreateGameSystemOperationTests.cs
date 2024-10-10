using Moq;
using Xunit;
using SystemOperations.SystemOperations;
using Entity;
using Repository.Repository;
using System.Data;
using Entity.Models.BaseEntityModel;
using Repository.Repository.RepositoryContracts;

namespace SystemOperations.Tests
{
    public class CreateGameSystemOperationTests
    {
        private readonly CreateGameSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public CreateGameSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new CreateGameSystemOperation
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_GameIsNull_ThrowsException()
        {
            // Arrange
            operation.Game = null;

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => operation.Execute());
            Assert.Equal("Game is null", exception.Message);

            mockRepository.Verify(r => r.Insert(It.IsAny<Game>()), Times.Never);
        }

        [Fact]
        public void ExecuteConcreteOperation_GameAlreadyExists_ThrowsException()
        {
            // Arrange
            var existingGame = new Game
            {
                GameId = 1,
                Team1 = new Team { Name = "Team A" },
                Team2 = new Team { Name = "Team B" },
                GameTime = DateTime.Now
            };

            operation.Game = existingGame;

            // Mock Select to return an existing game
            mockRepository
                .Setup(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()))
                .Returns(new List<IEntity> { existingGame });

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => operation.Execute());
            Assert.Equal("System can't create that game, because it already exists",
                exception.Message);

            mockRepository.Verify(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()),
                Times.Once);
            mockRepository.Verify(r => r.Insert(It.IsAny<Game>()), Times.Never);
        }

        [Fact]
        public void ExecuteConcreteOperation_GameIsValid_InsertsGameAndPlayerStats()
        {
            // Arrange
            var newGame = new Game
            {
                GameId = 1,
                Team1 = new Team { Name = "Team A" },
                Team2 = new Team { Name = "Team B" },
                GameTime = DateTime.Now,
                PlayersStatsList = new List<PlayerStatistics>
                {
                    new PlayerStatistics { PlayerId = 1, GameId = 1 },
                    new PlayerStatistics { PlayerId = 2, GameId = 1 }
                }
            };

            operation.Game = newGame;

            // Mock Select to return no games (i.e., game doesn't exist)
            mockRepository
                .Setup(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()))
                .Returns(new List<IEntity>());

            // Act
            operation.Execute();

            // Assert
            mockRepository.Verify(r => r.Select(It.IsAny<Game>(), It.IsAny<string>()),
                Times.Once);
            mockRepository.Verify(r => r.Insert(It.Is<Game>(g => g == newGame)),
                Times.Once);

            foreach (var ps in newGame.PlayersStatsList)
            {
                mockRepository.Verify(r => r.Insert(It.Is<PlayerStatistics>
                    (p => p.GameId == newGame.GameId)), Times.Exactly(2));
            }

            mockRepository.Verify(r => r.Commit(), Times.Once);
        }
    }
}
