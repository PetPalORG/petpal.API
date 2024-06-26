using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.IAM.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByUsernameAsync(string username);
        bool ExistsByUsername(string username);
    }
}
