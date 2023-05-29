using System.Collections.Generic;
using System.Threading.Tasks;
using github.Domain.Entity;
using github.Domain.Interfaces;
using github.Service;
using github.Service.GitHub;
using Moq;
using Xunit;

namespace github.Tests.Services
{
    public class BranchServiceTests
    {
        [Fact]
        public async Task ListBranches_Deve_Chamar_ListBranchAsync_Uma_Vez()
        {
            // Arrange
            int repositoryId = 123;
            var mockGithubAPIService = new Mock<IGithubAPIService>();
            var branchService = new BranchService(mockGithubAPIService.Object);

            // Act
            await branchService.ListBranchs(repositoryId);

            // Assert
            mockGithubAPIService.Verify(
                x => x.ListBranchAsync(repositoryId),
                Times.Once);
        }
    }
}