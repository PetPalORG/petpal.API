using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        { }

        public async Task<Pet?> FindByNameAsync(string Name)
        {
            return await Context.Set<Pet>().FirstOrDefaultAsync(p => p.Name == Name);
        }
    }
}
