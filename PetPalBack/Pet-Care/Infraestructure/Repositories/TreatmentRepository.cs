using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class TreatmentRepository: BaseRepository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(AppDbContext context) : base(context)
        { }
    }
}
