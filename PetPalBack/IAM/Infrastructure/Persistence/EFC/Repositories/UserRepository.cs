using Microsoft.EntityFrameworkCore;
using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.IAM.Domain.Repositories;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories;

namespace PetPalBack.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> FindByUsernameAsync(string username)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
        }

        public bool ExistsByUsername(string username)
        {
            return Context.Set<User>().Any(user => user.Username.Equals(username));
        }
    }
}
