using System;
using PetPalBack.Domain.Model.Entities;
using System.Threading.Tasks;
using PetPalBack.shared.Domain.Repositories;
namespace PetPalBack.Domain.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}

