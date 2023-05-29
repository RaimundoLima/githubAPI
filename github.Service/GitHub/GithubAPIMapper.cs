using AutoMapper;
using github.Domain.Entity;
using Octokit;
using Repository = github.Domain.Entity.Repository;
using Branch = github.Domain.Entity.Branch;
using Webhook = github.Domain.Entity.Webhook;

namespace github.Service.GitHub
{
    public class GithubAPIMapper : Profile
    {
        public GithubAPIMapper()
        {
            CreateMap<Octokit.Repository, Repository>();
                //.ForMember(dest => dest.Owner, opt => opt.MapFrom(x=>x.Owner))
                //.ForMember(dest => dest.License, opt => opt.MapFrom(x=>x.License))
                //.ForMember(dest => dest.Permissions, opt => opt.MapFrom(x=>x.Permissions));
            CreateMap<Repository, NewRepository>();

            CreateMap<Octokit.Branch, Branch>();

            CreateMap<Webhook, NewRepositoryHook>();
            CreateMap<Webhook, EditRepositoryHook>();
            CreateMap<RepositoryHook, Webhook>();
        }
    }
}
