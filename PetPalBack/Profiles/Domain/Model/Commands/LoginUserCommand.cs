
using System;
using MediatR;

namespace PetPalBack.Domain.Model.Commands
{
    public class LoginUserCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
