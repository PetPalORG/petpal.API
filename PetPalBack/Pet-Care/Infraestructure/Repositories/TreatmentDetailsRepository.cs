using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class TreatmentDetailsRepository: BaseRepository<TreatmentDetail>, ITreatmentDetailsRepository
    {
        public TreatmentDetailsRepository(AppDbContext context) : base(context)
        { }

        public new async Task<TreatmentDetail?> FindByIdAsync(int id) =>
            await Context.Set<TreatmentDetail>().Include(td => td.treatment)
            .Where(td => td.id == id).FirstOrDefaultAsync();

        public async Task<TreatmentDetail?> FindByTreatmentIdAsync(int treatmentId)
        {
            return await Context.Set<TreatmentDetail>()
                .Include(td => td.treatment)
                .Where(td => td.treatmentId == treatmentId)
                .FirstAsync();
        }

    }
}
