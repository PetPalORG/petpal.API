﻿using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Domain.Repositories
{
    public interface IMedicationRepository : IBaseRepository<Medication>
    {
        Task <IEnumerable<Medication>> FindByTreatmentIdAsync(int treatmentId);
    }
}
