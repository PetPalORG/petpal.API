using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class DietRepository: BaseRepository<Diet>, IDietRepository
    {
        public DietRepository(AppDbContext context) : base(context)
        { }

        public new async Task<Diet?> FindByIdAsync(int id) =>
            await Context.Set<Diet>().Include(d => d.pet)
            .Where(d => d.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Diet>> FindByPetIdAsync(int petId)
        {
            return await Context.Set<Diet>()
                .Include(d => d.pet)
                .Where(d => d.petId == petId)
                .ToListAsync();
        }
    }
}
