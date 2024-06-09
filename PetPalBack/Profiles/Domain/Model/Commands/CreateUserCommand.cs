using System;
using MediatR;
namespace PetPalBack.Domain.Model.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

