using System;
using Microsoft.EntityFrameworkCore;
using PetPalBack.Domain.Model.Entities;
using PetPalBack.Domain.Repositories;
using System.Threading.Tasks;


using PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;

namespace PetPalBack.Infrastructure.Persistence.EFC.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(AppDbContext context): base(context) {
        }

        public async Task AddAsync(User user)
        {
            await Context.AddAsync(user);
            await Context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
