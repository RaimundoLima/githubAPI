using github.Domain.Entity;

namespace github.Domain.Interfaces
{
    public interface IBranchService
    {
        Task<List<Branch>> ListBranchs(int repositoryId);
    }
}