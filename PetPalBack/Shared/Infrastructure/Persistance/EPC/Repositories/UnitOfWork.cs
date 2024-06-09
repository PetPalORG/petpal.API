using static PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories.UnitOfWork;
using PetPalBack.shared.Domain.Repositories;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;
using System;

namespace PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) => _context = context;
        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        
    }
}
