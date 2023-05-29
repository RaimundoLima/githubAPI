using github.Domain.Entity;
using github.Domain.Interfaces;
using github.Service.GitHub;

namespace github.Service
{
    public class BranchService : IBranchService
    {
        IGithubAPIService _githubAPIService;
        public BranchService(IGithubAPIService githubAPIService) 
        {
            _githubAPIService = githubAPIService;
        }

        public async Task<List<Branch>> ListBranchs(int repositoryId)
        {
            return await _githubAPIService.ListBranchAsync(repositoryId);
        }
    }
}
