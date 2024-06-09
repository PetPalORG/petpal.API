using System;
using MediatR;
using PetPalBack.Domain.Model.Entities;

namespace PetPalBack.Domain.Model.Queries
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
    }
}
