using AutoMapper;
using Octokit;
using Repository = github.Domain.Entity.Repository;
using Branch = github.Domain.Entity.Branch;
using Webhook = github.Domain.Entity.Webhook;
using ProductHeaderValue = Octokit.ProductHeaderValue;
using github.Domain.Entity;

namespace github.Service.GitHub
{
    public class GithubAPIService : IGithubAPIService
    {
        private IGitHubClient _client;
        private IMapper _githubAPIMapper;
        public GithubAPIService(IGitHubClient client,IMapper githubAPIMapper)
        {
            _githubAPIMapper = githubAPIMapper;
            _client = client;
        }


        public async Task<Repository> CreateRepositoryAsync(Repository repository)
        {
            var rep = await _client.Repository.Create(_githubAPIMapper.Map<NewRepository>(repository));
            return _githubAPIMapper.Map<Repository>(rep);

        }

        public async Task<Webhook> CreateWebhookAsync(Webhook webhook)
        {
            var hook = await _client.Repository.Hooks.Create(webhook.RepositoryId, _githubAPIMapper.Map<NewRepositoryHook>(webhook));
            return _githubAPIMapper.Map<Webhook>(hook);
        }

        public async Task<List<Branch>> ListBranchAsync(int repositoryId)
        {
            var branch = await _client.Repository.Branch.GetAll(repositoryId);
            return _githubAPIMapper.Map<List<Branch>>(branch);
        }

        public async Task<List<Webhook>> ListWebhooksAsync(int repositoryId)
        {
            var webhooks = await _client.Repository.Hooks.GetAll(repositoryId);
            return _githubAPIMapper.Map<List<Webhook>>(webhooks);
        }

        public void SetGitHubClient(IGitHubClient gitHubClient)
        {
            _client = gitHubClient;
        }

        public async Task<Webhook> UpdateWebhookAsync(Webhook webhook)
        {
            var hook = await _client.Repository.Hooks.Edit(webhook.RepositoryId,webhook.Id, _githubAPIMapper.Map<EditRepositoryHook>(webhook));
            return _githubAPIMapper.Map<Webhook>(hook);
        }
    }
}
