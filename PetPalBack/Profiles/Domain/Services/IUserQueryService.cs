using PetPalBack.Domain.Model.Entities;
using PetPalBack.Domain.Model.Queries;

namespace PetPalBack.Profiles.Domain.Services
{
    public interface IUserQueryService
    {
        Task<User?> Handle(GetUserByEmailQuery query);
    }
}
