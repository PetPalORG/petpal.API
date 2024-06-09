using System;
using MediatR;
using PetPalBack.Domain.Model.Commands;
using PetPalBack.Domain.Model.Entities;
using PetPalBack.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PetPalBack.Application.Internal.CommandServices
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return false;
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password, 
                RegistrationDate = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            return true;
        }
    }
}
