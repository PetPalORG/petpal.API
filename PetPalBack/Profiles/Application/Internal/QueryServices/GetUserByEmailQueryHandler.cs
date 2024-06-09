using System;
using MediatR;
using PetPalBack.Domain.Model.Entities;
using PetPalBack.Domain.Model.Queries;
using PetPalBack.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PetPalBack.Application.Internal.QueryServices
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByEmailAsync(request.Email);
        }
    }
}
