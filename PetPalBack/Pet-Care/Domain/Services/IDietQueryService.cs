using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IDietQueryService
    {
        Task<Diet?> Handle(GetDietByIdQuery query);
        Task<IEnumerable<Diet>> Handle(GetDietByPetIdQuery query);
    }
}
