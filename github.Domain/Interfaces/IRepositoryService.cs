using github.Domain.Entity;

namespace github.Domain.Interfaces
{
    public interface IRepositoryService
    {
        Task<Repository> CreateRepository(Repository repository);
    }
}
