using github.Domain.Interfaces;
using github.Service.GitHub;
using Repository = github.Domain.Entity.Repository;

namespace github.Service
{
    public class RepositoryService : IRepositoryService
    {
        IGithubAPIService _githubAPIService;
        public RepositoryService(IGithubAPIService githubAPIService) {
            _githubAPIService = githubAPIService;
        }
        public async Task<Repository> CreateRepository(Repository repository)
        {
            return await _githubAPIService.CreateRepositoryAsync(repository);
        }
    }
}
