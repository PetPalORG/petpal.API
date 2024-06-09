using Microsoft.EntityFrameworkCore;
using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.PetRegister.Domain.Repositories;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories;

namespace PetPalBack.PetRegister.Infraestructure.Repositories
{
    public class PetRepository: BaseRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {}

        public async Task<Pet?> FindByNameAsync(string Name)
        {
            return await Context.Set<Pet>().FirstOrDefaultAsync(p => p.Name == Name);
        }

        public async Task<IEnumerable<Pet>> FindByUserIdAsync(int userId)
        {
            return await Context.Set<Pet>().Where(u => u.UserId == userId).ToListAsync();
        }
    }
}
