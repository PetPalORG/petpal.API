using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class PetResourceFromEntityAssembler
    {
        public static PetResource ToResourceFromEntity(Pet entity)
        {
            return new PetResource(entity.Id, entity.Name, entity.Species, entity.Breed, entity.BirthDate, entity.Weight);
        }
    }
}
