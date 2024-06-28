using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class MealRepository: BaseRepository<Meal>, IMealRepository
    {
        public MealRepository(AppDbContext context) : base(context)
        { }

        public new async Task<Meal?> FindByIdAsync(int id) =>
            await Context.Set<Meal>().Include(d => d.pet)
            .Where(d => d.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Meal>> FindByPetIdAsync(int petId)
        {
            return await Context.Set<Meal>()
                .Include(d => d.pet)
                .Where(d => d.petId == petId)
                .ToListAsync();
        }
    }
}
