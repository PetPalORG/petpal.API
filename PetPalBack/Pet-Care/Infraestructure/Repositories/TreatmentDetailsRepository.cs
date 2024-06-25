using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class TreatmentDetailsRepository: BaseRepository<TreatmentDetail>, ITreatmentDetailsRepository
    {
        public TreatmentDetailsRepository(AppDbContext context) : base(context)
        { }
    }
}
