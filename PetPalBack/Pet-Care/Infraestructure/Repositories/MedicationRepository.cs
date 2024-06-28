using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;
using System.Linq.Expressions;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class MedicationRepository: BaseRepository<Medication>, IMedicationRepository
    {
        public MedicationRepository(AppDbContext context) : base(context)
        { }

        public async new Task<Medication?> FindByIdAsync(int id) =>
            await Context.Set<Medication>().Include(m => m.treatment)
            .Where(m => m.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Medication>> FindByTreatmentIdAsync(int treatmentId)
        {
            return await Context.Set<Medication>()
                .Include(m => m.treatment)
                .Where(m => m.treatmentId == treatmentId)
                .ToListAsync();
        }
    }
}
