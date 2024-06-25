using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class AppointmentRepository: BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        { }

        public new async Task<Appointment?> FindByIdAsync(int id) =>
            await Context.Set<Appointment>().Include(a => a.pet)
            .Where(a => a.id == id).FirstOrDefaultAsync();

        public new async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await Context.Set<Appointment>()
                .Include(a => a.pet)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> FindByPetIdAsync(int petId)
        {
            return await Context.Set<Appointment>()
                .Include(a => a.pet)
                .Where(a => a.petId == petId)
                .ToListAsync();
        }
    }
}
