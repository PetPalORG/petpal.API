using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;

namespace PetPalBack.Pet_Care.Application.Internal.QueryServices
{
    public class PetQueryService(IPetRepository petRepository) : IPetQueryService
    {
        public async Task<Pet?> Handle(GetPetByIdQuery query)
        {
            return await petRepository.FindByIdAsync(query.Id);
        }

        public async Task<IEnumerable<Pet>> Handle(GetAllPetsQuery query)
        {
            return await petRepository.ListAsync();
        }
    }
}
