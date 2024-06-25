using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.IAM.Domain.Model.Commands;

namespace PetPalBack.IAM.Domain.Services
{
    public interface IUserCommandService
    {
        Task Handle(SignUpCommand command);
        Task<(User user, string token)> Handle(SignInCommand command);
    }
}
