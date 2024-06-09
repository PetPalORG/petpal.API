using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.PetRegister.Domain.Model.Queries;
using PetPalBack.PetRegister.Domain.Repositories;
using PetPalBack.PetRegister.Domain.Services;

namespace PetPalBack.PetRegister.Application.Internal.QueryServices
{
    public class PetQueryService(IPetRepository petRepository) : IPetQueryService
    {
        public async Task<IEnumerable<Pet>> Handle(GetAllPetsByUserIdQuery query)
        {
            return await petRepository.FindByUserIdAsync(query.UserId);
        }

        public async Task<Pet?> Handle(GetPetByIdQuery query)
        {
            return await petRepository.FindByIdAsync(query.Id);
        }

        public async Task<Pet?> Handle(GetPetByNameQuery query)
        {
            return await petRepository.FindByNameAsync(query.Name);
        }
    }
}
