using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IPetQueryService
    {
        Task<Pet?> Handle(GetPetByIdQuery query);
    }
}
