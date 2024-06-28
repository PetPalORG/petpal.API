using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IPetQueryService
    {
        Task<IEnumerable<Pet>> Handle(GetAllPetsQuery query);
        Task<Pet?> Handle(GetPetByIdQuery query);
        Task<IEnumerable<Pet>> Handle(GetPetsByUserIdQuery query);
    }
}
