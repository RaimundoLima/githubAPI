using github.Domain.Entity;

namespace github.Service.GitHub
{
    public interface IGithubAPIService
    {
        public Task<Repository> CreateRepositoryAsync(Repository repository);
        public Task<List<Branch>> ListBranchAsync(int repositoryId);
        public Task<List<Webhook>> ListWebhooksAsync(int repositoryId);
        public Task<Webhook> CreateWebhookAsync(Webhook webhook);
        public Task<Webhook> UpdateWebhookAsync(Webhook webhook);

    }
}
