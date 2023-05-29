using System.Threading.Tasks;
using github.Domain.Entity;
using github.Domain.Interfaces;
using github.Service;
using github.Service.GitHub;
using Moq;
using Xunit;

namespace github.Tests.Services
{
    public class WebhookServiceTests
    {
        private readonly Mock<IGithubAPIService> _mockGithubAPIService;
        private readonly WebhookService _webhookService;

        public WebhookServiceTests()
        {
            _mockGithubAPIService = new Mock<IGithubAPIService>();
            _webhookService = new WebhookService(_mockGithubAPIService.Object);
        }

        [Fact]
        public async Task CreateWebhook_Deve_Chamar_CreateWebhookAsync_Uma_Vez()
        {
            // Arrange
            var webhook = new Webhook();

            // Act
            await _webhookService.CreateWebhook(webhook);

            // Assert
            _mockGithubAPIService.Verify(
                x => x.CreateWebhookAsync(webhook),
                Times.Once);
        }

        [Fact]
        public async Task ListWebhooks_Deve_Chamar_ListWebhooksAsync_Uma_Vez()
        {
            // Arrange
            int repositoryId = 123;

            // Act
            await _webhookService.ListWebhooks(repositoryId);

            // Assert
            _mockGithubAPIService.Verify(
                x => x.ListWebhooksAsync(repositoryId),
                Times.Once);
        }

        [Fact]
        public async Task UpdateWebhook_Deve_Chamar_UpdateWebhookAsync_Uma_Vez()
        {
            // Arrange
            var webhook = new Webhook();

            // Act
            await _webhookService.UpdateWebhook(webhook);

            // Assert
            _mockGithubAPIService.Verify(
                x => x.UpdateWebhookAsync(webhook),
                Times.Once);
        }
    }
}