using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class MedicationRepository: BaseRepository<Medication>, IMedicationRepository
    {
        public MedicationRepository(AppDbContext context) : base(context)
        { }

    }
}
