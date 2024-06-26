using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;

namespace PetPalBack.Pet_Care.Application.Internal.QueryServices
{
    public class DietQueryService(IDietRepository dietRepository): IDietQueryService
    {
        public async Task<Diet?> Handle(GetDietByIdQuery query)
        {
            return await dietRepository.FindByIdAsync(query.id);
        }

        public async Task<IEnumerable<Diet>> Handle(GetDietByPetIdQuery query)
        {
            return await dietRepository.FindByPetIdAsync(query.petId);
        }
    }
}
