using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface ITreatmentQueryService
    {
        Task<IEnumerable<Treatment>> Handle(GetAllTreatmentsQuery query);
        Task<Treatment?> Handle(GetTreatmentByIdQuery query);
        Task<IEnumerable<Treatment>> Handle(GetTreatmentByAppointmentIdQuery query);
    }
}
