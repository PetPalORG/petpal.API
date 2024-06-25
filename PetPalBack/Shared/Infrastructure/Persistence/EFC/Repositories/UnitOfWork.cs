using PetPalBack.Shared.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistance.EFC.Configurations;

namespace PetPalBack.Shared.Infrastructure.Persistance.EFC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) => _context = context;
        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        
    }
}
