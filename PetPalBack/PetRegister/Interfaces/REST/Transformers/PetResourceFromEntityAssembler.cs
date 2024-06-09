using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.PetRegister.Interfaces.REST.Resources;

namespace PetPalBack.PetRegister.Interfaces.REST.Transformers
{
    public class PetResourceFromEntityAssembler
    {
        public static PetResource ToResourceFromEntity(Pet entity)
        {
            return new PetResource(entity.Id, entity.Name, entity.Species, entity.Breed, entity.BirthDate, entity.Weight, entity.UserId);
        }
    }
}
