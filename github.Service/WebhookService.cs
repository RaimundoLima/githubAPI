using github.Domain.Entity;
using github.Domain.Interfaces;
using github.Service.GitHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace github.Service
{
    public class WebhookService : IWebhookService
    {
        IGithubAPIService _githubAPIService;
        public WebhookService(IGithubAPIService githubAPIService)
        {
            _githubAPIService = githubAPIService;
        }

        public Task<Webhook> CreateWebhook(Webhook webhook)
        {
            return _githubAPIService.CreateWebhookAsync(webhook);
        }

        public Task<List<Webhook>> ListWebhooks(int repositoryId)
        {
            return _githubAPIService.ListWebhooksAsync(repositoryId);
        }

        public Task<Webhook> UpdateWebhook(Webhook webhook)
        {
            return _githubAPIService.UpdateWebhookAsync(webhook);
        }
    }
}
