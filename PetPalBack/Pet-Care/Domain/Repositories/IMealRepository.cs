﻿using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Domain.Repositories
{
    public interface IMealRepository: IBaseRepository<Meal>
    {
        Task <IEnumerable<Meal>> FindByPetIdAsync(int petId);
    }
}
