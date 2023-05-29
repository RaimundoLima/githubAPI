using AutoMapper;
using github.Domain.DTO;
using github.Domain.Entity;


namespace github.Domain.Mappers
{
    public class WebhookMapper : Profile
    {
        public WebhookMapper()
        {
            CreateMap<CreateWebhookDTO, Webhook>();

            CreateMap<UpdateWebhookDTO, Webhook>();
            CreateMap<Webhook, ViewWebhookDTO>();
        }
    }
}
