using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using github.Domain.Entity;
using github.Domain.Interfaces;
using github.Service.GitHub;
using Moq;
using Octokit;
using Xunit;
using Branch = github.Domain.Entity.Branch;
using Repository = github.Domain.Entity.Repository;

namespace github.Tests.Services
{
    public class GithubAPIServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IGitHubClient> _mockGithubClient;
        private readonly Mock<IRepositoriesClient> _mockRepositoriesClient;
        private readonly Mock<IRepositoryHooksClient> _mockRepositoryHooksClient;
        private readonly Mock<IRepositoryBranchesClient> _mockRepositoryBranchesClient;
        private readonly GithubAPIService _githubAPIService;
        string _name = "teste";
        Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public GithubAPIServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockGithubClient = new Mock<IGitHubClient>();
            _mockRepositoriesClient = new Mock<IRepositoriesClient>();
            _mockRepositoryHooksClient = new Mock<IRepositoryHooksClient>();
            _mockRepositoryBranchesClient = new Mock<IRepositoryBranchesClient>();
            _githubAPIService = new GithubAPIService(CreateMockGitHubClient(), _mockMapper.Object);
            _name = "teste";
            _dictionary = new Dictionary<string, string>();

        }

        private IGitHubClient CreateMockGitHubClient()
        {
            var mockGitHubClient = new Mock<IGitHubClient>();
            mockGitHubClient.SetupGet(x => x.Repository).Returns(_mockRepositoriesClient.Object);
            mockGitHubClient.SetupGet(x => x.Repository.Hooks).Returns(_mockRepositoryHooksClient.Object);
            mockGitHubClient.SetupGet(x => x.Repository.Branch).Returns(_mockRepositoryBranchesClient.Object);
            return mockGitHubClient.Object;
        }

        [Fact]
        public async Task CreateRepositoryAsync_Deve_Chamar_RepositoryCreate_UmaVez()
        {
            // Arrange
            var repository = new Repository();
            var newRepository = new NewRepository(_name);
            _mockMapper.Setup(x => x.Map<NewRepository>(repository)).Returns(newRepository);

            // Act
            await _githubAPIService.CreateRepositoryAsync(repository);

            // Assert
            _mockRepositoriesClient.Verify(x => x.Create(newRepository), Times.Once);
        }

        [Fact]
        public async Task CreateWebhookAsync_Deve_Chamar_RepositoryHooksCreate_UmaVez()
        {
            // Arrange
            var webhook = new Webhook();
            var newRepositoryHook = new NewRepositoryHook(_name, _dictionary);
            _mockMapper.Setup(x => x.Map<NewRepositoryHook>(webhook)).Returns(newRepositoryHook);

            // Act
            await _githubAPIService.CreateWebhookAsync(webhook);

            // Assert
            _mockRepositoryHooksClient.Verify(x => x.Create(webhook.RepositoryId, newRepositoryHook), Times.Once);
        }

        [Fact]
        public async Task ListBranchAsync_Deve_Chamar_RepositoryBranchGetAll_UmaVez()
        {
            // Arrange
            int repositoryId = 123;
            var branches = new List<Branch>();

            // Act
            await _githubAPIService.ListBranchAsync(repositoryId);

            // Assert
            _mockRepositoriesClient.Verify(x => x.Branch.GetAll(repositoryId), Times.Once);
        }

        [Fact]
        public async Task ListWebhooksAsync_Deve_Chamar_RepositoryHooksGetAll_UmaVez()
        {
            // Arrange
            int repositoryId = 123;
            var webhooks = new List<Webhook>();

            // Act
            await _githubAPIService.ListWebhooksAsync(repositoryId);

            // Assert
            _mockRepositoryHooksClient.Verify(x => x.GetAll(repositoryId), Times.Once);
        }

        [Fact]
        public async Task UpdateWebhookAsync_Deve_Chamar_RepositoryHooksEdit_UmaVez()
        {
            // Arrange
            var webhook = new Webhook();
            var editRepositoryHook = new EditRepositoryHook();
            _mockMapper.Setup(x => x.Map<EditRepositoryHook>(webhook)).Returns(editRepositoryHook);

            // Act
            await _githubAPIService.UpdateWebhookAsync(webhook);

            // Assert
            _mockRepositoryHooksClient.Verify(x => x.Edit(webhook.RepositoryId, webhook.Id, editRepositoryHook), Times.Once);
        }
    }
}