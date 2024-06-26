using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.IAM.Domain.Model.Queries;
using PetPalBack.IAM.Domain.Repositories;
using PetPalBack.IAM.Domain.Services;

namespace PetPalBack.IAM.Application.Internal.QueryServices
{
    public class UserQueryService(IUserRepository userRepository) : IUserQueryService
    {
        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await userRepository.FindByIdAsync(query.Id);
        }

        public async Task<User?> Handle(GetUserByUsernameQuery query)
        {
            return await userRepository.FindByUsernameAsync(query.Username);
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
        {
            return await userRepository.ListAsync();
        }
    }
}
