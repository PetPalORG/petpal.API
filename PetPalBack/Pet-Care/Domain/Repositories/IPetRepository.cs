﻿using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Domain.Repositories
{
    public interface IPetRepository : IBaseRepository<Pet>
    {
        Task<Pet?> FindByNameAsync(string name);
        Task<IEnumerable<Pet>> FindByUserIdAsync(int userId);
        
    }
}
