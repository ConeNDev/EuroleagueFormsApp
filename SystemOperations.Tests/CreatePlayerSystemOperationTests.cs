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
    public class CreatePlayerSystemOperationTests
    {
        private readonly CreatePlayerSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public CreatePlayerSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new CreatePlayerSystemOperation
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_PlayerIsNull_ThrowsException()
        {
            // Arrange
            operation.Player = null;

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => operation.Execute());
            Assert.Equal("Player is null", exception.Message);

            mockRepository.Verify(r => r.Insert(It.IsAny<Player>()), Times.Never);
        }

        [Fact]
        public void ExecuteConcreteOperation_PlayerIsValid_InsertsPlayer()
        {
            // Arrange
            var newPlayer = new Player
            {
                PlayerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Team = new Team()
                {
                    TeamId = 1
                },
            };

            operation.Player = newPlayer;

            // Act
            operation.Execute();

            // Assert
            mockRepository.Verify(r => r.Insert(It.Is<Player>(p => p == newPlayer)), Times.Once);
            mockRepository.Verify(r => r.Commit(), Times.Once);
        }
    }
}
