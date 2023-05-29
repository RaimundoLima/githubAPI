using AutoMapper;
using github.Domain.DTO;
using github.Domain.Entity;

namespace github.Domain.Mappers
{
    public class RepositoryMapper : Profile
    {
        public RepositoryMapper()
        {
            CreateMap<CreateRepositoryDTO, Repository>();
            CreateMap<Repository, ViewRepositoryDTO>();
        }
    }
}
