using static PetPalBack.Shared.Infrastructure.Persistance.EPC.Repositories.UnitOfWork;
using PetPalBack.Shared.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration;
using System;

namespace PetPalBack.Shared.Infrastructure.Persistance.EPC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) => _context = context;
        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        
    }
}
