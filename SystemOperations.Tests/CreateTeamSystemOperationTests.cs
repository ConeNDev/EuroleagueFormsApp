using Entity;
using Entity.Models.BaseEntityModel;
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
    public class CreateTeamSystemOperationTests
    {
        private readonly CreateTeamSystemOperation operation;
        private readonly Mock<GenericDbRepository> mockRepository;

        public CreateTeamSystemOperationTests()
        {
            mockRepository = new Mock<GenericDbRepository>();
            operation = new CreateTeamSystemOperation
            {
                repository = mockRepository.Object
            };
        }

        [Fact]
        public void ExecuteConcreteOperation_TeamIsNull_ThrowsException()
        {
            // Arrange
            operation.Team = null;

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => operation.Execute());
            Assert.Equal("Team is null", exception.Message);

            // Verify that Insert was never called
            mockRepository.Verify(r => r.Insert(It.IsAny<Team>()), Times.Never);
        }

        [Fact]
        public void ExecuteConcreteOperation_TeamAlreadyExists_ThrowsException()
        {
            // Arrange
            var existingTeam = new Team
            {
                TeamId = 1,
                Name = "Team A",
                Coach = "Coach A"
            };

            operation.Team = new Team
            {
                Name = "Team A",
                Coach = "Coach A"
            };

            // Mock repository to return a list with an existing team
            mockRepository
                .Setup(r => r.Select(It.IsAny<Team>(), It.IsAny<string>()))
                .Returns(new List<IEntity> { existingTeam });

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => operation.Execute());
            Assert.Equal("System can't create that team, because it already exists", exception.Message);

            // Verify that Insert was never called since team exists
            mockRepository.Verify(r => r.Insert(It.IsAny<Team>()), Times.Never);
        }

        [Fact]
        public void ExecuteConcreteOperation_TeamIsValid_InsertsTeam()
        {
            // Arrange
            var newTeam = new Team
            {
                TeamId = 2,
                Name = "Team B",
                Coach = "Coach B"
            };

            operation.Team = newTeam;

            // Mock repository to return an empty list (team does not exist)
            mockRepository
                .Setup(r => r.Select(It.IsAny<Team>(), It.IsAny<string>()))
                .Returns(new List<IEntity>());

            // Act
            operation.Execute();

            // Assert
            mockRepository.Verify(r => r.Insert(It.Is<Team>(t => t == newTeam)), Times.Once);
            mockRepository.Verify(r => r.Commit(), Times.Once);
        }
    }
}
