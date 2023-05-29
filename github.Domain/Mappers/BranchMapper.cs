using AutoMapper;
using github.Domain.DTO;
using github.Domain.Entity;

namespace github.Domain.Mappers
{
    public class BranchMapper : Profile
    {
        public BranchMapper()
        {
            CreateMap<Branch, ViewBranchDTO>();
        }
    }
}
