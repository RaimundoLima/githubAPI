using github.Domain.Entity;

namespace github.Domain.Interfaces
{
    public interface IWebhookService
    {
        Task<List<Webhook>> ListWebhooks(int repositoryId);
        Task<Webhook> CreateWebhook(Webhook webhook);
        Task<Webhook> UpdateWebhook(Webhook webhook);
    }
}
