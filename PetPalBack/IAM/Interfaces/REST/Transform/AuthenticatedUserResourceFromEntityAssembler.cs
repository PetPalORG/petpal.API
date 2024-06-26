using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.IAM.Interfaces.REST.Resources;

namespace PetPalBack.IAM.Interfaces.REST.Transform
{
    public static class AuthenticatedUserResourceFromEntityAssembler
    {
        public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
        {
            return new AuthenticatedUserResource(entity.Id, entity.Username, token);
        }
    }
}
