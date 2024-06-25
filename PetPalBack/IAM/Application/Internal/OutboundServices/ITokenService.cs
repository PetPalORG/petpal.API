using PetPalBack.IAM.Domain.Model.Aggregates;

namespace PetPalBack.IAM.Application.Internal.OutboundServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        Task<int?> ValidateToken(string token);
    }
}
