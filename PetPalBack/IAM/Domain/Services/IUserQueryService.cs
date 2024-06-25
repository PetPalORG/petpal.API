using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.IAM.Domain.Model.Queries;

namespace PetPalBack.IAM.Domain.Services
{
    public interface IUserQueryService
    {
        Task<User?> Handle(GetUserByIdQuery query);
        Task<User?> Handle(GetUserByUsernameQuery query);
        Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    }
}
