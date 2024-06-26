using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.IAM.Interfaces.REST.Resources;

namespace PetPalBack.IAM.Interfaces.REST.Transform
{
    public static class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(User entity)
        {
            return new UserResource(entity.Id, entity.Username);
        }
    }
}
