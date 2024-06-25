using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class DietResourceFromEntityAssembler
    {
        public static DietResource ToResourceFromEntity(Diet entity)
        {
            return new DietResource(entity.Id, entity.Food, entity.Date, PetResourceFromEntityAssembler.ToResourceFromEntity(entity.pet));
        }
    }
}
