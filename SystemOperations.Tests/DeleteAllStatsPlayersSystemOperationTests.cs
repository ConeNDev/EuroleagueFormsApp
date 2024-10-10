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
    public class DeleteAllStatsPlayersSystemOperationTests
    {
        private readonly DeleteAllStatsPlayersSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public DeleteAllStatsPlayersSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new DeleteAllStatsPlayersSystemOperation
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_GameIsNull_ThrowsException()
        {
            // Arrange
            operation.game = null;

            // Act & Assert
            var exception = Assert.Throws<NullReferenceException>(() => operation.Execute());
            Assert.Equal("Object reference not set to an instance of an object.", exception.Message);

            // Verify that Delete was never called
            mockRepository.Verify(r => r.Delete(It.IsAny<PlayerStatistics>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ExecuteConcreteOperation_DeletesAllPlayerStatsForGame()
        {
            // Arrange
            var game = new Game
            {
                GameId = 1,
                GameTime = DateTime.Now
            };

            operation.game = game;

            // Act
            operation.Execute();

            // Assert
            mockRepository.Verify(r => r.Delete(It.IsAny<PlayerStatistics>(), It.Is<string>(criteria => criteria == $"GameId = '{game.GameId}'")), Times.Once);
            mockRepository.Verify(r => r.Commit(), Times.Once);
        }
    }
}
