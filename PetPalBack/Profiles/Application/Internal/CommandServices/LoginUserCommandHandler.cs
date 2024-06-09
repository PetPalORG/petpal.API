using System;
using MediatR;
using PetPalBack.Domain.Model.Commands;
using PetPalBack.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PetPalBack.Application.Internal.CommandServices
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || user.Password != request.Password) 
            {
                return false;
            }


            return true;
        }
    }
}
