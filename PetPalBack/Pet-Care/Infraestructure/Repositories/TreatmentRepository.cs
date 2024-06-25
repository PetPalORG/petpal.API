using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;
using System.Runtime.InteropServices;

namespace PetPalBack.Pet_Care.Infraestructure.Repositories
{
    public class TreatmentRepository: BaseRepository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(AppDbContext context) : base(context)
        { }

        public new async Task<Treatment?> FindByIdAsync(int id) =>
            await Context.Set<Treatment>().Include(t => t.appointment)
            .Where(t => t.Id == id).FirstOrDefaultAsync();

        public new async Task<IEnumerable<Treatment>> ListAsync()
        {
            return await Context.Set<Treatment>()
                .Include(t => t.appointment)
                .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> FindByAppointmentIdAsync(int appointmentId)
        {
            return await Context.Set<Treatment>()
                .Include(t => t.appointment)
                .Where(t => t.appointmentId == appointmentId)
                .ToListAsync();
        }
    }
}
