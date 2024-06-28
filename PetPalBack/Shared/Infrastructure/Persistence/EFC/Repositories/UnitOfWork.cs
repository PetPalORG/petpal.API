using PetPalBack.Shared.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task CompleteAsync() => await context.SaveChangesAsync();
    }
}
