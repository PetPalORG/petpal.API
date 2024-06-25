using PetPalBack.IAM.Application.Internal.OutboundServices;
using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.IAM.Domain.Model.Commands;
using PetPalBack.IAM.Domain.Repositories;
using PetPalBack.IAM.Domain.Services;
using PetPalBack.IAM.Infrastructure.Hashing.BCrypt.Services;
using PetPalBack.IAM.Infrastructure.Tokens.JWT.Services;
using PetPalBack.shared.Domain.Repositories;

namespace PetPalBack.IAM.Application.Internal.CommandServices
{
    public class UserCommandService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService
    ) : IUserCommandService
    {
        public async Task Handle(SignUpCommand command)
        {
            if (userRepository.ExistsByUsername(command.Username))
                throw new Exception($"Username {command.Username} is already taken");

            var hashedPassword = hashingService.HashPassword(command.Password);
            var user = new User(command.Username, hashedPassword);
            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while creating the user: {e.Message}");
            }
        }

        public async Task<(User user, string token)> Handle(SignInCommand command)
        {
            var user = await userRepository.FindByUsernameAsync(command.Username);

            if (user is null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
                throw new Exception("Invalid username or password");

            var token = tokenService.GenerateToken(user);

            return (user, token);
        }
    }
}
