using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.PetRegister.Domain.Model.Queries;

namespace PetPalBack.PetRegister.Domain.Services
{
    public interface IPetQueryService
    {
        Task<IEnumerable<Pet>> Handle(GetAllPetsByUserIdQuery query);
        Task<Pet?> Handle(GetPetByIdQuery query);
        Task<Pet?> Handle(GetPetByNameQuery query);
    }
}
