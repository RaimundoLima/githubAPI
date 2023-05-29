using github.Domain.Entity;
using github.Service;
using github.Service.GitHub;
using Moq;
using Xunit;


namespace github.Tests.Services
{
    public class RepositoryServiceTests
    {
        [Fact]
        public async Task CreateWebhook_Deve_Chamar_CreateWebhookAsync_Uma_Vez()
        {
            // Arrange
            var mockGithubAPIService = new Mock<IGithubAPIService>();
            var repositoryService = new RepositoryService(mockGithubAPIService.Object);
            Repository repository = new Repository();

            // Act
            await repositoryService.CreateRepository(repository);

            // Assert
            mockGithubAPIService.Verify(
                x => x.CreateRepositoryAsync(repository),
                Times.Once);
        }
    }
}