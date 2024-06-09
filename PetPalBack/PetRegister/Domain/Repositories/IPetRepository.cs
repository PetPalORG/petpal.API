using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.shared.Domain.Repositories;

namespace PetPalBack.PetRegister.Domain.Repositories
{
    public interface IPetRepository: IBaseRepository<Pet>
    {
        Task<IEnumerable<Pet>> FindByUserIdAsync(int userId);
        Task<Pet?> FindByNameAsync(string Name);
    }
}
