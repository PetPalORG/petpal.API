using PetPalBack.Domain.Model.Commands;
using PetPalBack.Domain.Model.Entities;

namespace PetPalBack.Profiles.Domain.Services
{
    public interface IUserCommandService
    {
        Task<User?> Handle(CreateUserCommand command); 
    }
}
